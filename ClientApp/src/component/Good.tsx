import * as React from 'react'
import { bindActionCreators } from 'redux'
import { addItem, deleteItem, initGood } from '../action/index'
import { connect } from 'react-redux'
interface GoodProps {
	addItem?: (action: any) => void;
	deleteItem?: (action: any) => void;
	initGood: (url: string, pageIndex: number) => void;
	dispatch?: (action: any) => void;
}
interface Item {
	id: number;
	title: string;
}
	
interface GoodSate {
	goods: Item[];
}
const Good = ({ dispatch, addItem, deleteItem, goods, initGood }: GoodProps & GoodSate) => {
	React.useEffect(() => {
		initGood("api/Default",1);
	},[])
	return <div>Goods!</div>
}
function mapStateToProps(state: GoodSate) {
	const { goods } = state
	return { goods};
}

function mapDispatchToProps(dispatch: any) {
	return bindActionCreators({ addItem,deleteItem,initGood }, dispatch)
}

export default connect(mapStateToProps, mapDispatchToProps)(Good)
