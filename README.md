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
Tested VScode version: 1.3.1, 1.5.1, 1.5.2. ( may be available VScode 1.3.0 or above.)  

* Run as Administrator( to access `Program Files (x86)` )
* VScode installed at `C:\Program Files (x86)\Microsoft VS Code`
* vscode-markdown located at `C:\Program Files (x86)\Microsoft VS Code\resources\app\extensions\markdown`
* vscode-markdown `markdown-it` version. (tested version is vscode-markdown 0.2.0)

---

## What will happen, after this code run.

This program insert one line to `C:\Program Files (x86)\Microsoft VS Code\resources\app\extensions\markdown\out\extension.js`.

```js
    MDDocumentContentProvider.prototype.createRenderer = function () {
        var hljs = require('highlight.js');
        var mdnh = require('markdown-it-named-headers');
        var md = require('markdown-it')({
            html: true,
            highlight: function (str, lang) {
```
to
```js
    MDDocumentContentProvider.prototype.createRenderer = function () {
        var hljs = require('highlight.js');
        var mdnh = require('markdown-it-named-headers');
        var md = require('markdown-it')({
            breaks: vscode.workspace.getConfiguration('markdown')['markdown-it-breaks']||false,
            html: true,
            highlight: function (str, lang) {
```

This program alsow backup `extension.js` to `extension.js.yyyyMMddHHmmss.backup` in same folder.

That's all.
