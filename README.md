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

---

Requirement:

OS : Windows
.NET Framework: 3.5
Tested VScode version: 1.5.2 ( may be 1.4 also ok.)

* VScode installed at `C:\Program Files (x86)\Microsoft VS Code`
* vscode-markdown located at `C:\Program Files (x86)\Microsoft VS Code\resources\app\extensions\markdown`
* vscode-markdown `markdown-it` version. (tested version is vscode-markdown 0.2.0)
