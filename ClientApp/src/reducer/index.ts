import { ACTION_TYPES } from '../action/index'
import { fade } from '@material-ui/core';


interface Item {
	id: number;
	title: string;
}
interface Action {
	type: string;
	payload: any;
}
interface ContentState {
	goods: Item[];
	isLoading: boolean;
}
const initState = {
	goods: [],
	isLoading: false
};


export default (state: ContentState = initState, action: Action): any => {

	switch (action.type) {
		case ACTION_TYPES.INIT_GOOD:
			return {
				...state,
				goods: action.payload.goods,
				isLoading: false
			};
		default:
			return state;
	}
}   