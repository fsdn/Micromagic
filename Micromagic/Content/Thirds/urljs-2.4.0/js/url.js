﻿;
/**
 * v2.4.0
 */
"use strict";
var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) {
    return typeof obj
}
: function (obj) {
    return obj && typeof Symbol === "function" && obj.constructor === Symbol ? "symbol" : typeof obj
}
;
(function (f) {
    if ((typeof exports === "undefined" ? "undefined" : _typeof(exports)) === "object" && typeof module !== "undefined") {
        module.exports = f()
    } else if (typeof define === "function" && define.amd) {
        define([], f)
    } else {
        var g;
        if (typeof window !== "undefined") {
            g = window
        } else if (typeof global !== "undefined") {
            g = global
        } else if (typeof self !== "undefined") {
            g = self
        } else {
            g = this
        }
        g.Url = f()
    }
})(function () {
    var define, module, exports;
    return function e(t, n, r) {
        function s(o, u) {
            if (!n[o]) {
                if (!t[o]) {
                    var a = typeof require == "function" && require;
                    if (!u && a)
                        return a(o, !0);
                    if (i)
                        return i(o, !0);
                    var f = new Error("Cannot find module '" + o + "'");
                    throw f.code = "MODULE_NOT_FOUND",
                    f
                }
                var l = n[o] = {
                    exports: {}
                };
                t[o][0].call(l.exports, function (e) {
                    var n = t[o][1][e];
                    return s(n ? n : e)
                }, l, l.exports, e, t, n, r)
            }
            return n[o].exports
        }
        var i = typeof require == "function" && require;
        for (var o = 0; o < r.length; o++) {
            s(r[o])
        }
        return s
    }({
        1: [function (require, module, exports) {
            window.addEventListener("popstate", function (e) {
                Url.triggerPopStateCb(e)
            });
            var Url = module.exports = {
                _onPopStateCbs: [],
                _isHash: false,
                queryString: function queryString(name, notDecoded) {
                    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
                    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)")
                      , results = regex.exec(location.search)
                      , encoded = null;
                    if (results === null) {
                        regex = new RegExp("[\\?&]" + name + "(\\&([^&#]*)|$)");
                        if (regex.test(location.search)) {
                            return true
                        }
                        return undefined
                    } else {
                        encoded = results[1].replace(/\+/g, " ");
                        if (notDecoded) {
                            return encoded
                        }
                        return decodeURIComponent(encoded)
                    }
                },
                parseQuery: function parseQuery(search) {
                    var query = {};
                    if (typeof search !== "string") {
                        search = window.location.search
                    }
                    search = search.replace(/^\?/g, "");
                    if (!search) {
                        return {}
                    }
                    var a = search.split("&"), i = 0, iequ, value = null;
                    for (; i < a.length; ++i) {
                        iequ = a[i].indexOf("=");
                        if (iequ < 0) {
                            iequ = a[i].length;
                            value = true
                        } else {
                            value = decodeURIComponent(a[i].slice(iequ + 1))
                        }
                        query[decodeURIComponent(a[i].slice(0, iequ))] = value
                    }
                    return query
                },
                stringify: function stringify(queryObj) {
                    if (!queryObj || queryObj.constructor !== Object) {
                        throw new Error("Query object should be an object.")
                    }
                    var stringified = "";
                    Object.keys(queryObj).forEach(function (c) {
                        var value = queryObj[c];
                        stringified += c;
                        if (value !== true) {
                            stringified += "=" + encodeURIComponent(queryObj[c])
                        }
                        stringified += "&"
                    });
                    stringified = stringified.replace(/\&$/g, "");
                    return stringified
                },
                updateSearchParam: function updateSearchParam(param, value, push, triggerPopState) {
                    var searchParsed = this.parseQuery();
                    if (value === undefined) {
                        delete searchParsed[param]
                    } else {
                        if (searchParsed[param] === value) {
                            return Url
                        }
                        searchParsed[param] = value
                    }
                    var newSearch = "?" + this.stringify(searchParsed);
                    this._updateAll(window.location.pathname + newSearch + location.hash, push, triggerPopState);
                    return Url
                },
                getLocation: function getLocation() {
                    return window.location.pathname + window.location.search + window.location.hash
                },
                hash: function hash(newHash, triggerPopState) {
                    if (newHash === undefined) {
                        return location.hash.substring(1)
                    }
                    if (!triggerPopState) {
                        setTimeout(function () {
                            Url._isHash = false
                        }, 0);
                        Url._isHash = true
                    }
                    return location.hash = newHash
                },
                _updateAll: function _updateAll(s, push, triggerPopState) {
                    window.history[push ? "pushState" : "replaceState"](null, "", s);
                    if (triggerPopState) {
                        Url.triggerPopStateCb({})
                    }
                    return s
                },
                pathname: function pathname(_pathname, push, triggerPopState) {
                    if (_pathname === undefined) {
                        return location.pathname
                    }
                    return this._updateAll(_pathname + window.location.search + window.location.hash, push, triggerPopState)
                },
                triggerPopStateCb: function triggerPopStateCb(e) {
                    if (this._isHash) {
                        return
                    }
                    this._onPopStateCbs.forEach(function (c) {
                        c(e)
                    })
                },
                onPopState: function onPopState(cb) {
                    this._onPopStateCbs.push(cb)
                },
                removeHash: function removeHash() {
                    this._updateAll(window.location.pathname + window.location.search, false, false)
                },
                removeQuery: function removeQuery() {
                    this._updateAll(window.location.pathname + window.location.hash, false, false)
                },
                version: "2.3.1"
            }
        }
        , {}]
    }, {}, [1])(1)
});
