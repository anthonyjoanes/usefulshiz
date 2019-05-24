# Dealing with NODE and node-gyp

When performing an `npm i` after a node upgrade I had many problems with `node-pre-gyp` and getting this to work properly. In the end a combination of the following seemed to have fixed it.

`npm install -g node-pre-gyp`
`npm install -g node-gyp`
`node-gyp configure`

The I reinstalled all the `node_modules` packages with a `npm i`.

