"use strict";
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var index_1 = require("../action/index");
var initState = {
    goods: [],
    isLoading: false
};
exports.default = (function (state, action) {
    if (state === void 0) { state = initState; }
    switch (action.type) {
        case index_1.ACTION_TYPES.INIT_GOOD:
            return __assign({}, state, { goods: action.payload.goods, isLoading: false });
        default:
            return state;
    }
});
//# sourceMappingURL=index.js.map