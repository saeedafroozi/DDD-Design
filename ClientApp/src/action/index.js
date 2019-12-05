"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var index_1 = require("../constant/index");
exports.ACTION_TYPES = {
    ADD_ITEM: 'ADD_ITEM',
    DELETE_ITEM: 'DELETE_ITEM',
    INIT_GOOD: 'INIT_GOOD',
    SET_ISLOADING: 'SET_ISLOADING',
    SHOW_ERROR: 'SHOW_ERROR'
};
exports.initGood = function (url, pageIndex) { return function (dispatch) {
    dispatch(exports.setIsLoading(true));
    return fetch(url, index_1.fetchConfig)
        .then(function (response) {
        response.json()
            .then(function (data) {
            dispatch({
                type: exports.ACTION_TYPES.INIT_GOOD,
                payload: data
            });
        });
    }).catch(function (ex) { return dispatch(fetchFailure(ex)); });
}; };
function fetchFailure(ex) {
    return {
        type: exports.ACTION_TYPES.SHOW_ERROR,
        payload: { ex: 'fetchFailure' }
    };
}
exports.addItem = function (name) {
    return {
        type: exports.ACTION_TYPES.ADD_ITEM,
        payload: { title: name }
    };
};
exports.setIsLoading = function (isLoading) {
    return {
        type: exports.ACTION_TYPES.SET_ISLOADING,
        payload: isLoading
    };
};
exports.deleteItem = function (id) {
    return {
        type: exports.ACTION_TYPES.DELETE_ITEM,
        payload: { id: id }
    };
};
//# sourceMappingURL=index.js.map