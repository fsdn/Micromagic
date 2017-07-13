

// #region angular

var app = angular.module('app', []);

// #endregion

// #region console

var isDebug = true;
/** log.debug */
function funLogDebug() {
    var args = $.extend([], arguments);
    if (isDebug) {
        funLog.apply(this, args);
        //console.assert() // debug的绝佳方法
    }
}

/** console.log */
function funLog() {
    var args = $.extend([], arguments);
    if (window.console) {
        console.log.apply(console, args);
    }

    ////// jquery下简化 console.log 的写法改进版；http://www.cnblogs.com/jozhi88/p/3785207.html
    ////if (window.console) {        
    ////    var k = arguments, c;
    ////    try {
    ////        k.callee = funLog.caller;
    ////    } catch (e) { }
    ////    c = [].slice.call(k);
    ////    if (typeof console.log === 'object') {
    ////        log.apply.call(console.log, console, c);
    ////    }
    ////    else {
    ////        console.log.apply(console, c);
    ////    }
    ////}
}



// #endregion