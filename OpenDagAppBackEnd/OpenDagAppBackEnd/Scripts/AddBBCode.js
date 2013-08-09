/**
 * BB Code insertions
 */
$(document).ready(function () {
    $("button#bb-img").click(function () { $('#bb-post-field').insertRoundCaret('[img]', '[/img]') });
    $("button#bb-b").click(function () { $('#bb-post-field').insertRoundCaret('[b]', '[/b]') });
    $("button#bb-i").click(function () { $('#bb-post-field').insertRoundCaret('[i]', '[/i]') });
    $("button#bb-u").click(function () { $('#bb-post-field').insertRoundCaret('[u]', '[/u]') });
    $("button#bb-url").click(function () { $('#bb-post-field').insertRoundCaret('[url=linkhier]', '[/url]') });
    $("button#bb-list").click(function () { $('#bb-post-field').insertRoundCaret('[list]', '[/list]') });
    $("button#bb-asterisk").click(function () { $('#bb-post-field').insertAtCaret('[*]') });
    $("button#bb-color").click(function () { $('#bb-post-field').insertRoundCaret('[color=kleur]', '[/color]') });
    $("button#bb-quote").click(function () { $('#bb-post-field').insertRoundCaret('[quote=auteur]', '[/quote]') });
});

/**
 * Inserts specified text at caret position.
 * 
 * @param tagName Text to insert
 */
$.fn.insertAtCaret = function (tagName) {
    return this.each(function () {
        if (document.selection) {
            //IE support
            this.focus();
            sel = document.selection.createRange();
            sel.text = tagName;
            this.focus();
        } else if (this.selectionStart || this.selectionStart == '0') {
            //MOZILLA/NETSCAPE support
            startPos = this.selectionStart;
            endPos = this.selectionEnd;
            scrollTop = this.scrollTop;
            this.value = this.value.substring(0, startPos) + tagName + this.value.substring(endPos, this.value.length);
            this.focus();
            this.selectionStart = startPos + tagName.length;
            this.selectionEnd = startPos + tagName.length;
            this.scrollTop = scrollTop;
        } else {
            this.value += tagName;
            this.focus();
        }
    });
};

/**
 * Inserts specified tags at the start and end of
 * a selected piece of text.
 * 
 * @param tagStart
 * @param tagEnd
 */
$.fn.insertRoundCaret = function (tagStart, tagEnd) {
    return this.each(function () {
        strStart = tagStart;
        strEnd = tagEnd;
        if (document.selection) {
            //IE support
            stringBefore = this.value;
            this.focus();
            sel = document.selection.createRange();
            insertstring = sel.text;
            fullinsertstring = strStart + sel.text + strEnd;
            sel.text = fullinsertstring;
            document.selection.empty();
            this.focus();
            stringAfter = this.value;
            i = stringAfter.lastIndexOf(fullinsertstring);
            range = this.createTextRange();
            numlines = stringBefore.substring(0, i).split("\n").length;
            i = i + 3 - numlines + tagName.length;
            j = insertstring.length;
            range.move("character", i);
            range.moveEnd("character", j);
            range.select();
        } else if (this.selectionStart || this.selectionStart == '0') {
            //MOZILLA/NETSCAPE support
            startPos = this.selectionStart;
            endPos = this.selectionEnd;
            scrollTop = this.scrollTop;
            this.value = this.value.substring(0, startPos) + strStart + this.value.substring(startPos, endPos) + strEnd + this.value.substring(endPos, this.value.length);
            this.focus();
            this.selectionStart = startPos + strStart.length;
            this.selectionEnd = endPos + strStart.length;
            this.scrollTop = scrollTop;
        } else {
            this.value += strStart + strEnd;
            this.focus();
        }
    });
};