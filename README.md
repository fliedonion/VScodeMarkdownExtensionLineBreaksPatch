# LineBreaks patch for VScode-Markdown internal extension.

after this patch success, you can specify markdown-it's `breaks` option in settings like following:

```
    "markdown.markdown-it-breaks": true
```

|name|default|description|
|-----|:-:|-------------|
|markdown.markdown-it-breaks|false|same as markdown-it `breaks` option.new line inside markdown will be compile to `<br/>` in preview.|

after change setting, you must be reopen vscode. ( Window opened by `Open New Window` menu, also affected )

```json
// Place your settings in this file to overwrite the default settings
{
    "markdown.markdown-it-breaks": true
}
```
