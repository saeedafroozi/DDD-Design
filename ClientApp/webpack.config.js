"use strict";

var path = require("path");
var WebpackNotifierPlugin = require("webpack-notifier");
var BrowserSyncPlugin = require("browser-sync-webpack-plugin");

module.exports = {
	entry: "../ClientApp/src/index.tsx",
	output: {
		path: path.resolve(__dirname, "../wwwroot/build"),
		filename: "bundle.js"
	},
	module: {
		rules: [
			{
				test: /\.(s*)css$/,
				use: ['style-loader', 'css-loader', 'sass-loader'],
			},
			{
				test: /\.tsx?$/,
				loader: 'ts-loader',
				options: {
					transpileOnly: true
				}
			}
		]
	},
	resolve: {
		alias: {
			'react': path.join(__dirname, 'node_modules', 'react')
		},
		extensions: ['.json', '.tsx', '.ts', '.js']
	},
	externals: {
		"react": "React",
		"react-dom": "ReactDOM",
	},
	devtool: "inline-source-map",
	plugins: [new WebpackNotifierPlugin(), new BrowserSyncPlugin()]
};