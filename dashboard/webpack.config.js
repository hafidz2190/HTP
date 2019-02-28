const ExtractTextPlugin = require('extract-text-webpack-plugin');
module.exports = {
    entry: './src/index.js',
    output: {
        path: `${__dirname}/public/`,
        publicPath: '/public/',
        filename: 'bundle.js'
    },
    devServer: {
        inline: true,
        port: 2507,
        contentBase: './public'
    }, node: {
        fs: 'empty'
    },
    resolve: {
        // Add '.ts' and '.tsx' as resolvable extensions.
        extensions: ['.ts', '.tsx', '.js', '.jsx', '.json', '.less', '.svg']
    },
    module: {
        loaders: [
            {
                test: /\.html$/,
                loader: 'file-loader?name=[name].[ext]'
            },
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                loader: 'babel-loader',
                query: {
                    presets: ['es2015', 'react', 'stage-2']
                }
            },
            {
                test: /\.(css|less)$/,
                use: ExtractTextPlugin.extract({
                    fallback: 'style-loader',
                    use: ['css-loader', 'less-loader']
                })
            },
            {
                test: /\.svg$/,
                loader: 'file-loader',
                options: {
                    name: 'svg/[hash].[ext]'
                }
            }
        ]
    },
    plugins: [
        new ExtractTextPlugin('styles.css')
    ]
};