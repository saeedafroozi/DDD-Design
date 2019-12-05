"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var React = require("react");
var redux_1 = require("redux");
var index_1 = require("../action/index");
var react_redux_1 = require("react-redux");
var Good = function (_a) {
    var dispatch = _a.dispatch, addItem = _a.addItem, deleteItem = _a.deleteItem, goods = _a.goods, initGood = _a.initGood;
    React.useEffect(function () {
        initGood("api/Default/GetGoods", 1);
    }, []);
    return React.createElement("div", null, "Goods!");
};
function mapStateToProps(state) {
    var goods = state.goods;
    return { goods: goods };
}
function mapDispatchToProps(dispatch) {
    return redux_1.bindActionCreators({ addItem: index_1.addItem, deleteItem: index_1.deleteItem, initGood: index_1.initGood }, dispatch);
}
exports.default = react_redux_1.connect(mapStateToProps, mapDispatchToProps)(Good);
//# sourceMappingURL=Good.js.map