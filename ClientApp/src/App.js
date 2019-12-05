"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
require("./StyleSheet.scss");
var redux_1 = require("redux");
var index_1 = require("../src/reducer/index");
var react_redux_1 = require("react-redux");
var react_router_dom_1 = require("react-router-dom");
var Good_1 = require("../src/component/Good");
var Customer_1 = require("../src/component/Customer");
var Seller_1 = require("../src/component/Seller");
var AppBar_1 = require("@material-ui/core/AppBar");
var Toolbar_1 = require("@material-ui/core/Toolbar");
var IconButton_1 = require("@material-ui/core/IconButton");
var redux_thunk_1 = require("redux-thunk");
var store = redux_1.createStore(index_1.default, redux_1.applyMiddleware(redux_thunk_1.default));
var App = function () {
    return (React.createElement(react_redux_1.Provider, { store: store },
        React.createElement(react_router_dom_1.BrowserRouter, null,
            React.createElement("div", { className: "menu" },
                React.createElement(AppBar_1.default, { position: "static" },
                    React.createElement(Toolbar_1.default, null,
                        React.createElement(IconButton_1.default, null,
                            React.createElement(react_router_dom_1.Link, { to: "/Good" }, "Good")),
                        React.createElement(IconButton_1.default, null,
                            React.createElement(react_router_dom_1.Link, { to: "/customer" }, "Customer")),
                        React.createElement(IconButton_1.default, null,
                            React.createElement(react_router_dom_1.Link, { to: "/seller" }, "Seller"))))),
            React.createElement("div", { className: "app" },
                React.createElement(react_router_dom_1.Route, { path: "/Good", component: Good_1.default }),
                React.createElement(react_router_dom_1.Route, { path: "/customer", component: Customer_1.default }),
                React.createElement(react_router_dom_1.Route, { path: "/seller", component: Seller_1.default })))));
};
exports.default = App;
//# sourceMappingURL=App.js.map