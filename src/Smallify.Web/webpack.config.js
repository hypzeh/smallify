const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const ScriptExtHtmlWebpackPlugin = require('script-ext-html-webpack-plugin');

module.exports = {
	entry: './ClientApp/index.js',
	output: {
		filename: 'main.js',
		path: path.resolve(__dirname, 'wwwroot')
	},
	devServer: {
		contentBase: path.join(__dirname, 'wwwroot'),
		compress: true,
		hot: true
	},
	module: {
		rules: [
			{
				test: /\.(js|jsx)$/,
				exclude: /node_modules/,
				loader: 'babel-loader'
			},
			{
				test: /\.(pdf|jpg|png|gif|svg|ico)$/,
				use: [
					'file-loader',
					{
						loader: 'img-loader',
						options: {
							plugins: [
								require('imagemin-mozjpeg')({
									progressive: true
								}),
								require('imagemin-pngquant')({
									floyd: 0.5,
									speed: 5
								})
							]
						}
					}
				]
			}
		]
	},
	plugins: [
		new HtmlWebpackPlugin({
			template: './ClientApp/template.html',
			filename: 'index.html',
			favicon: './wwwroot/favicon.ico',
			minify: {
				collapseWhitespace: true,
				removeComments: true,
				removeRedundantAttributes: true,
				removeScriptTypeAttributes: true,
				removeStyleLinkTypeAttributes: true,
				useShortDoctype: true
			}
		}),
		new ScriptExtHtmlWebpackPlugin({
			prefetch: /\.js$/,
			defaultAttribute: 'async'
		})
	]
};
