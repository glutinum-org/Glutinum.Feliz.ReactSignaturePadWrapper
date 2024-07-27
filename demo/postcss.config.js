import purgecss from '@fullhuman/postcss-purgecss'

export default {
    plugins: [
        purgecss({
            content: ['./**/*.html', './**/*.fs.js'],
            variables: true,
        })
    ]
}
