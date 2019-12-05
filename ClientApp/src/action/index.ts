
import { getData, postData, fetchConfigGet } from '../constant/index'

export const ACTION_TYPES = {
	ADD_ITEM: 'ADD_ITEM',
	DELETE_ITEM: 'DELETE_ITEM',
	INIT_GOOD: 'INIT_GOOD',
	SET_ISLOADING: 'SET_ISLOADING',
	SHOW_ERROR: 'SHOW_ERROR'
}

interface Item {
	id: number;
	title: string;
}



export const initGood = (url: string, pageIndex: number) => dispatch => {
	dispatch(setIsLoading(true));
	return fetch(`${url}/${pageIndex}`, {
		...fetchConfigGet,
	})
		.then(response => {
			response.json()
				.then((data: Item[]) => {
					dispatch({
						type: ACTION_TYPES.INIT_GOOD,
						payload: data
					});
				})
		}).catch(ex => dispatch(fetchFailure(ex)))
	//try {
	//	const data = await getData(url, { pageIndex: pageIndex }) ;
	//	dispatch({
	//		type: ACTION_TYPES.INIT_GOOD,
	//		payload: data
	//	});
	//} catch (ex) {
	//	dispatch(fetchFailure(ex))
	//}
}
function fetchFailure(ex) {

	return {
		type: ACTION_TYPES.SHOW_ERROR,
		payload: { ex: 'fetchFailure' }
	};
}
export const addItem = (name: string) => {

	return {
		type: ACTION_TYPES.ADD_ITEM,
		payload: { title: name }
	};

}
export const setIsLoading = (isLoading: boolean) => {
	return {
		type: ACTION_TYPES.SET_ISLOADING,
		payload: isLoading
	};
}
export const deleteItem = (id: string) => {

	return {
		type: ACTION_TYPES.DELETE_ITEM,
		payload: { id: id }
	};

}