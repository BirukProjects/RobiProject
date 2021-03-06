define(["require", "exports", "../utils", "./templateEngine", "./contextmenu", "../ui", "../store"], function(require, exports, __utils__, __engine__, __ctx__, __ui__, __store__) {
    var utils = __utils__;
    var engine = __engine__;
    var ctx = __ctx__;
    var ui = __ui__;
    var store = __store__;

    var stateCacheKey = "__SPA_TREE_STATE__", stateActiveKey = "__SPA_TREE_ACTIVE_ITEM__";

    function typeValueOrDefault(param, type, viewModel, index) {
        var globalDefault = viewModel.defaults[param];
        if (viewModel.defaults[type] === undefined || viewModel.defaults[type][param] === undefined) {
            return ko.utils.unwrapObservable(globalDefault);
        }

        return ko.utils.unwrapObservable(viewModel.defaults[type][param]);
    }

    exports.defaults = {
        cssClass: "ui-tree",
        isDraggable: true,
        isDropTarget: true,
        canAddChildren: true,
        childType: "folder",
        renameAfterAdd: true,
        connectToSortable: false,
        dragCursorAt: { left: 28, bottom: 0 },
        dragCursor: "auto",
        dragHelper: function (event, element) {
            return $("<div></div>").addClass("drag-icon").append($("<span></span>").addClass(this.cssClass()));
        }
    };

    var Tree = (function () {
        function Tree(options) {
            this.engine = engine.defaultInstance;
            this.defaults = {};
            this.handlers = {
                selectNode: function (node, onSuccess) {
                    console.log("select node " + node.name());
                    onSuccess();
                },
                addNode: function (parent, type, name, onSuccess) {
                    console.log("add new ui.treeNode");
                    onSuccess({ id: 10, parent: parent, name: name });
                },
                renameNode: function (node, from, to, onSuccess) {
                    console.log("rename node '" + from + "' to '" + to + "'");
                    onSuccess();
                },
                deleteNode: function (node, action, onSuccess) {
                    console.log("delete node '" + node.name() + "'");
                    onSuccess();
                },
                moveNode: function (node, newParent, newIndex, onSuccess) {
                    console.log("move node '" + node.name() + "' to '" + newParent.name ? newParent.name() : "root" + "'");
                    onSuccess();
                },
                doubleClick: function (node) {
                    console.log("doubled clicked " + node.name());
                },
                rightClick: function (node) {
                    console.log("right click " + node.name());
                },
                startDrag: function (node) {
                    console.log("start drag");
                },
                endDrag: function (node) {
                    console.log("stop drag");
                }
            };
            this.isDragging = ko.observable(false);
            this.tree = null;
            utils.extend(this.defaults, exports.defaults, options.defaults || {});
            utils.extend(this.handlers, options.handlers || {});

            this.id = utils.createObservable(options.id);
            this.remember = utils.createObservable(options.remember, false);
            this.dragHolder = utils.createObservable(options.dragHolder);

            this.children = utils.createObservableArray(options.children, this.createNode, this);
            this.selectedNode = utils.createObservable(options.selectedNode);

            if (options.contextMenu) {
                this.contextMenu = new ctx.ContextMenuBuilder(options.contextMenu);
            }
        }
        Tree.prototype.findNode = function (id) {
            var result;

            this.children.find(function (node) {
                if (node.id() === id) {
                    result = node;
                    return true;
                }

                result = node.findNode(id);
                return !!result;
            });

            return result;
        };
        Tree.prototype.selectNode = function (id, root) {
            var _this = this;
            var level = root || this;

            var result = level.children.find(function (node) {
                if (node.id() === id) {
                    node.selectNode();
                    return true;
                }

                if (_this.selectNode(id, node)) {
                    node.isOpen(true);
                    return true;
                } else {
                    return false;
                }
            });

            return !!result;
        };

        Tree.prototype.addNode = function (node) {
            var _this = this;
            if (node instanceof TreeNode) {
                var selected = node.isSelected();

                node.isSelected(false);
                node.setViewModel(this);
                node.parent(this);

                this.children.push(node);

                selected && node.selectNode();
            } else {
                if ((node !== undefined && node.parent === undefined) || this.children().length === 0) {
                    var type = node.type !== undefined ? node.type : typeValueOrDefault("childType", undefined, this), name = node.name !== undefined ? node.name : typeValueOrDefault("name", type, this), rename = node.rename !== undefined ? node.rename : typeValueOrDefault("renameAfterAdd", type, this);

                    this.handlers.addNode(undefined, type, name, function (data) {
                        if (data !== undefined) {
                            var newNode = new TreeNode(data, _this, _this);
                            _this.children.push(newNode);

                            var selected = newNode.isSelected();
                            if (selected || rename) {
                                newNode.isSelected(false);
                                newNode.selectNode();
                            }

                            rename && newNode.isRenaming(true);

                            _this.recalculateSizes();
                            newNode.saveState();
                        }
                    });
                } else {
                    this.selectedNode().addChild(node || {});
                }
            }
        };
        Tree.prototype.renameNode = function (node) {
            node = node || this.selectedNode();
            node && node.isRenaming(true);
        };
        Tree.prototype.deleteNode = function (action, node) {
            node = node || this.selectedNode();
            node && node.deleteSelf(action);
        };
        Tree.prototype.deleteAll = function () {
            this.children.each(function (node) {
                return node.deleteSelf();
            });
        };
        Tree.prototype.clear = function () {
            this.children([]);
        };

        Tree.prototype.recalculateSizes = function () {
            var maxNodeWidth = 0, widestNode;
            $(".node:visible", this.tree).each(function (ind1, node) {
                var newWidth = 0, $this = $(node);
                newWidth = newWidth + $this.children("label").outerWidth(true);
                newWidth = newWidth + $this.children(".icon").outerWidth(true);
                newWidth = newWidth + $this.children(".handle").outerWidth(true);

                if (maxNodeWidth < newWidth) {
                    maxNodeWidth = newWidth;
                    widestNode = $this;
                }
            });
            $(".node", this.tree).css("minWidth", maxNodeWidth + 5);
        };

        Tree.prototype.createNode = function (node, index) {
            if (node instanceof TreeNode) {
                node.setViewModel(this);
                node.parent(this);
                return node;
            } else {
                return new TreeNode(node, this, this, index);
            }
        };
        return Tree;
    })();
    exports.Tree = Tree;

    var TreeNode = (function () {
        function TreeNode(options, parent, viewModel, index) {
            var _this = this;
            this.viewModel = viewModel;
            this.isDragging = ko.observable(false);
            var defaultType = typeValueOrDefault("childType", parent === viewModel ? undefined : parent.type(), viewModel);

            this.parent = ko.observable(parent);
            this.contextMenu = viewModel ? viewModel.contextMenu : null;

            this.id = utils.createObservable(options.id);
            this.name = utils.createObservable(options.name);
            this.type = utils.createObservable(options.type, defaultType);
            this.cssClass = utils.createObservable(options.cssClass, this.type());
            this.iconCssClass = utils.createObservable(options.iconCssClass, "");
            this.index = utils.createObservable(options.index, utils.isUndefined(index) ? parent.children().length : index);
            this.remember = parent.remember;

            this.isOpen = utils.createObservable(options.isOpen, false);
            this.isSelected = utils.createObservable(options.isSelected, false);
            this.isRenaming = utils.createObservable(options.isRenaming, false);
            this.isDragging = ko.observable(false);

            this.contents = options.contents;
            this.children = utils.createObservableArray(options.children, this.createChild, this);

            this.canAddChildren = ko.computed(function () {
                return typeValueOrDefault("canAddChildren", _this.type(), _this.viewModel);
            });
            this.showAddBefore = ko.computed(function () {
                var parent = _this.parent(), dragHolder = viewModel.dragHolder();

                if (parent.canAddChildren && parent.canAddChildren() && parent.isDropTarget && parent.isDropTarget() && viewModel.isDragging()) {
                    if (dragHolder === _this) {
                        return false;
                    } else if (dragHolder.parent() === parent) {
                        return (dragHolder.index() - _this.index()) !== -1;
                    } else {
                        return true;
                    }
                }

                return false;
            });
            this.showAddAfter = ko.computed(function () {
                var parent = _this.parent(), dragHolder = viewModel.dragHolder();

                if (parent.canAddChildren && parent.canAddChildren() && parent.isDropTarget() && viewModel.isDragging()) {
                    if (dragHolder === _this) {
                        return false;
                    } else if (dragHolder.parent() === parent) {
                        return (dragHolder.index() - _this.index()) !== 1;
                    } else {
                        return true;
                    }
                }

                return false;
            });

            this.isDropTarget = ko.computed(function () {
                return typeValueOrDefault("isDropTarget", _this.type(), _this.viewModel);
            });
            this.connectToSortable = ko.computed(function () {
                return typeValueOrDefault("connectToSortable", _this.type(), _this.viewModel);
            });
            this.isDraggable = ko.computed(function () {
                var name = _this.name(), childRenaming = false, typeDefault = typeValueOrDefault("isDraggable", _this.type(), _this.viewModel);

                _this.children.find(function (child) {
                    return (childRenaming = child.isRenaming());
                });

                return !_this.isRenaming() && !childRenaming && typeDefault;
            });

            this.level = ko.computed(function () {
                try  {
                    var plevel = _this.parent().level();
                    return plevel + 1;
                } catch (err) {
                    return 0;
                }
            });

            this.loadState();

            _.bindAll(this, "toggle", "clicked", "doubleClick");
        }
        TreeNode.prototype.hasChildren = function () {
            return this.children.size() > 0;
        };
        TreeNode.prototype.hasContext = function () {
            return !!this.contextMenu;
        };
        TreeNode.prototype.uniqueIdentifier = function () {
            return this.viewModel.id() + this.type() + this.id();
        };

        TreeNode.prototype.createChild = function (node, index) {
            if (node instanceof TreeNode) {
                node.setViewModel(this.viewModel);
                node.parent(this);

                return node;
            } else {
                return new TreeNode(node, this, this.viewModel, index);
            }
        };
        TreeNode.prototype.setViewModel = function (viewModel) {
            this.children.each(function (child) {
                return child.setViewModel(viewModel);
            });

            this.viewModel = viewModel;
            this.contextMenu = viewModel.contextMenu;
        };

        TreeNode.prototype.findNode = function (id) {
            var result;

            this.children.find(function (node) {
                if (node.id() === id) {
                    result = node;
                    return true;
                }

                result = node.findNode(id);
                return !!result;
            });

            return result;
        };
        TreeNode.prototype.selectNode = function () {
            var _this = this;
            var selected = this.viewModel.selectedNode();

            if (selected !== undefined && selected.isRenaming()) {
                $(".rename > .node input", this.viewModel.tree).blur();
            }

            this.saveState();

            if (selected === undefined || (selected !== undefined && selected !== this)) {
                this.viewModel.handlers.selectNode(this, function () {
                    if (selected !== undefined) {
                        selected.isSelected(false);
                        selected.isRenaming(false);
                    }

                    _this.openParents();
                    _this.isSelected(true);
                    _this.viewModel.selectedNode(_this);
                    _this.saveState();
                });
            }
        };

        TreeNode.prototype.openParents = function () {
            var current = this.parent();
            while (current.parent !== undefined) {
                current.isOpen(true);
                current = current.parent();
            }
        };
        TreeNode.prototype.openSelfAndParents = function () {
            this.isOpen(true);
            this.openParents();
        };
        TreeNode.prototype.toggle = function () {
            this.isOpen(!this.isOpen());
            this.viewModel.recalculateSizes();
            this.saveState();
        };

        TreeNode.prototype.addChild = function (node) {
            var _this = this;
            if (this.canAddChildren()) {
                var defaultType = typeValueOrDefault("childType", this.type(), this.viewModel), type = node.type !== undefined ? node.type : defaultType, defaultName = typeValueOrDefault("name", type, this.viewModel), name = node.name !== undefined ? node.name : defaultName, rename = node.rename !== undefined ? node.rename : typeValueOrDefault("renameAfterAdd", type, this.viewModel);

                this.viewModel.handlers.addNode(this, type, name, function (data) {
                    if (data !== undefined) {
                        var newNode = new TreeNode(data, _this, _this.viewModel);
                        _this.children.push(newNode);
                        _this.openSelfAndParents();

                        var selected = newNode.isSelected();
                        if (selected || rename) {
                            newNode.isSelected(false);
                            _this.isSelected(false);
                            newNode.selectNode();
                        }

                        rename && newNode.isRenaming(true);

                        _this.viewModel.recalculateSizes();
                        _this.saveState();
                    }
                });
            }
        };
        TreeNode.prototype.rename = function (newName) {
            var _this = this;
            this.viewModel.handlers.renameNode(this, this.name(), newName, function () {
                _this.name(newName);
                _this.viewModel.recalculateSizes();
            });
        };
        TreeNode.prototype.deleteSelf = function (action) {
            var _this = this;
            this.viewModel.handlers.deleteNode(this, action, function () {
                var parent = _this.parent();

                _this.children.each(function (child) {
                    return child.deleteSelf(action + " child");
                });

                if (parent !== undefined) {
                    parent.children.remove(_this);

                    if (!action || action.indexOf("child") === -1) {
                        var tIndex = _this.index();
                        parent.children.each(function (child) {
                            var index = child.index();
                            (index > tIndex) && child.index(index - 1);
                        });
                    }
                }

                _this.viewModel.recalculateSizes();
            });
        };

        TreeNode.prototype.move = function (node, parent, index) {
            var _this = this;
            var newParent = parent || this, oldParent = node.parent(), newIndex = typeof index === "undefined" ? newParent.children.size() : index, oldIndex = node.index();

            this.viewModel.handlers.moveNode(node, newParent, newIndex, function () {
                oldParent.children.remove(node);

                oldParent.children.each(function (child) {
                    var index = child.index();
                    (index > oldIndex) && child.index(index - 1);
                });

                node.index(newIndex);
                node.parent(newParent);

                oldParent.children.each(function (child) {
                    var index = child.index();
                    (index >= newIndex) && child.index(index + 1);
                });

                newParent.children.splice(newIndex, 0, node);
                newParent.isOpen && newParent.isOpen(true);

                node.selectNode();
                _this.viewModel.recalculateSizes();
                _this.saveState();
            });
        };
        TreeNode.prototype.moveBefore = function (node) {
            this.move(node, this.parent(), this.index());
        };
        TreeNode.prototype.moveAfter = function (node) {
            this.move(node, this.parent(), this.index() + 1);
        };

        TreeNode.prototype.getDragHolder = function () {
            return this.viewModel.dragHolder();
        };
        TreeNode.prototype.setDragHolder = function (event, element) {
            this.viewModel.dragHolder(this);
        };

        TreeNode.prototype.loadState = function () {
            if (!this.remember()) {
                return;
            }

            var state = JSON.parse(store.getItem(stateCacheKey)), uid = this.uniqueIdentifier();

            if (state) {
                var itemState = state[uid];
                if (itemState && itemState.open === true) {
                    this.isOpen(true);
                }

                var active = state[stateActiveKey];
                if (active && active === uid) {
                    this.isSelected(true);
                }
            }
        };
        TreeNode.prototype.saveState = function () {
            if (!this.remember()) {
                return;
            }

            var state = JSON.parse(store.getItem(stateCacheKey)) || {}, uid = this.uniqueIdentifier();

            state[uid] = { open: this.isOpen() };

            if (this.isSelected()) {
                state[stateActiveKey] = uid;
            }

            store.setItem(stateCacheKey, JSON.stringify(state));
        };

        TreeNode.prototype.clicked = function (node, event) {
            switch (event.which) {
                case 1:
                    this.selectNode();
                    break;
                case 3:
                    this.viewModel.handlers.rightClick(this);
                    break;
            }
        };
        TreeNode.prototype.doubleClick = function (event) {
            this.viewModel.handlers.doubleClick(this);
        };
        return TreeNode;
    })();
    exports.TreeNode = TreeNode;

    ui.addTemplate("text!ui-tree-item-template.html", "<li data-bind=\"contextmenu: contextMenu, css: { empty: !hasChildren(), open: isOpen, rename: isRenaming }, hover: 'hover', classes: cssClass, attr: { 'data-id': id() }\">" + "<!-- ko if: showAddBefore() --><div class=\"node-order top\" data-bind=\"hover: 'hover', treenodedrop: { active : true, onDropComplete: moveBefore }\"></div><!-- /ko -->" + "<div class=\"node\" data-bind=\"treenodedrag: isDraggable(), treenodedrop: { active : isDropTarget(), onDropComplete: move }, css: { selected: isSelected }, hover: 'hover', event: { dblclick: doubleClick, mousedown: clicked }\">" + "<!-- ko if: hasChildren() --><span class=\"handle\" data-bind=\"click: toggle, hover : 'hover'\"></span><!-- /ko -->" + "<!-- ko ifnot: hasChildren() --><span class=\"handle\"></span><!-- /ko -->" + "<span class=\"icon\" data-bind=\"classes: iconCssClass\"></span>" + "<label data-bind=\"visible: !isRenaming(), text: name\" unselectable=\"on\"></label>" + "<input class=\"rename\" type=\"text\" data-bind=\"treenoderename: name, onRenameComplete : rename, treenodeselectvisible: isRenaming\"/>" + "</div>" + "<!-- ko if: showAddAfter() --><div class=\"node-order bottom\" data-bind=\"hover: 'hover', treenodedrop: { active : true, onDropComplete: moveAfter }\"></div><!-- /ko -->" + "<!-- ko if: hasChildren() -->" + "<ul data-bind='visible: isOpen, template: { name: \"text!ui-tree-item-template.html\", foreach: children, templateEngine: $root.engine }'></ul>" + "<!-- /ko -->" + "</li>", engine.defaultInstance);

    ui.addTemplate("text!ui-tree-container-template.html", "<div><ul class=\"ui-tree\" data-bind=\"template: { name : 'text!ui-tree-item-template.html', foreach: $data.children, templateEngine: $data.engine }\"></ul></div>", engine.defaultInstance);

    ko.bindingHandlers.treenodedrag = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var $element = $(element), node = viewModel, dragOptions = {
                revert: "invalid",
                revertDuration: 250,
                cancel: "span.handle",
                cursor: typeValueOrDefault("dragCursor", node.type(), node.viewModel),
                cursorAt: typeValueOrDefault("dragCursorAt", node.type(), node.viewModel),
                appendTo: "body",
                connectToSortable: viewModel.connectToSortable(),
                helper: function (event, element) {
                    var helper = typeValueOrDefault("dragHelper", node.type(), node.viewModel);
                    return helper.call(viewModel, event, element);
                },
                zIndex: 200000,
                addClasses: false,
                distance: 10,
                start: function (e, ui) {
                    viewModel.setDragHolder();
                    viewModel.isDragging(true);
                    viewModel.viewModel.handlers.startDrag(viewModel);
                    viewModel.viewModel.isDragging(true);
                },
                stop: function (e, ui) {
                    viewModel.isDragging(false);
                    viewModel.viewModel.handlers.endDrag(viewModel);
                    viewModel.viewModel.isDragging(false);
                }
            };

            $element.draggable(dragOptions);
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var $element = $(element), active = ko.utils.unwrapObservable(valueAccessor());

            if (!active) {
                $element.draggable("disable");
            } else {
                $element.draggable("enable");
            }
        }
    };
    ko.bindingHandlers.treenodedrop = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var $element = $(element), value = valueAccessor() || {}, handler = ko.utils.unwrapObservable(value.onDropComplete), dropOptions = {
                greedy: true,
                tolerance: "pointer",
                addClasses: false,
                drop: function (e, ui) {
                    setTimeout(function () {
                        handler.call(viewModel, viewModel.getDragHolder());
                    }, 0);
                }
            };
            $element.droppable(dropOptions);
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var $element = $(element), active = ko.utils.unwrapObservable(valueAccessor()).active;

            if (!active) {
                $element.droppable("disable");
            } else {
                $element.droppable("enable");
            }
        }
    };

    ko.bindingHandlers.treenodeselectvisible = {
        update: function (element, valueAccessor) {
            ko.bindingHandlers.visible.update.call(this, element, valueAccessor);
            var isCurrentlyInvisible = element.style.display === "none";
            if (!isCurrentlyInvisible) {
                element.select();
            }
        }
    };

    function nodeRenameUpdateValue(element, valueAccessor, allBindingsAccessor, viewModel) {
        var handler = allBindingsAccessor().onRenameComplete, elementValue = ko.selectExtensions.readValue(element);

        handler.call(viewModel, elementValue);
        viewModel.isRenaming(false);
    }
    ko.bindingHandlers.treenoderename = {
        init: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            var $element = $(element), updateHandler = function () {
                nodeRenameUpdateValue(element, valueAccessor, allBindingsAccessor, viewModel);
            };

            $element.click(function () {
                return false;
            }).focus("focus", function () {
            });
            $element.bind("blur", _.partial(nodeRenameUpdateValue, element, valueAccessor, allBindingsAccessor, viewModel));
            $element.bind("keyup", function (e) {
                return (e.which === 13) && updateHandler();
            });
        },
        update: function (element, valueAccessor, allBindingsAccessor, viewModel) {
            ko.bindingHandlers.value.update.call(this, element, valueAccessor);
        }
    };

    ko.bindingHandlers.tree = {
        init: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            value.tree = element;
            console.log("Initialize tree " + value.children().length + " root nodes found");

            return { controlsDescendantBindings: true };
        },
        update: function (element, valueAccessor) {
            var value = ko.utils.unwrapObservable(valueAccessor());
            ko.renderTemplate("text!ui-tree-container-template.html", value, { templateEngine: engine.defaultInstance }, element);
            value.recalculateSizes();
        }
    };
});
