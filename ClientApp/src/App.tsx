import * as  React from 'react';
import './StyleSheet.scss';
import { createStore, applyMiddleware } from 'redux'
import reducer from '../src/reducer/index'
import { Provider } from 'react-redux'
import { BrowserRouter, Route, Link } from 'react-router-dom';
import Items from './component/index'
import Good from '../src/component/Good'
import Customer from '../src/component/Customer'
import Seller from '../src/component/Seller'
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import IconButton from '@material-ui/core/IconButton'
import thunk from 'redux-thunk';

const store = createStore(
	reducer, applyMiddleware(thunk)
);



const App: React.FC = () => {
	return (
		<Provider store={store}>
			<BrowserRouter>
				<div className="menu">
					<AppBar position="static">
						<Toolbar >
							<IconButton>
								<Link to="/Good">Good</Link>
							</IconButton>
							<IconButton>
								<Link  to="/customer">Customer</Link>
							</IconButton>
							<IconButton>
								<Link  to="/seller">Seller</Link>
							</IconButton>
						</Toolbar>
					</AppBar>
				</div>
				<div className="app">
					<Route path="/Good" component={Good} />
					<Route path="/customer" component={Customer} />
					<Route path="/seller" component={Seller} />
				</div>
			</BrowserRouter>
		</Provider>
	);
}

export default App;
