import tsconfigPaths from "vite-tsconfig-paths";
import path from 'path'
export default {
    plugins: [tsconfigPaths()],
    resolve: {
        alias: {
            '@': path.resolve(__dirname, './src')
        }
    },
    test: {
        includeSource: ['src/**/*.{js,ts}'],
    },
}

