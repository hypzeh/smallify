const presets = [
	['@babel/preset-env', {
		targets: 'last 1 version',
		shippedProposals: true
	}],
	['@babel/preset-react', {
		useBuiltIns: true
	}]
];

const plugins = [];

module.exports = {presets, plugins};
