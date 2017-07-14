
// #region name

$().ready(function () {
    funDataInit(); // 初始化数据
    funEventInit(); // 初始化事件
});

/** 初始化数据 */
function funDataInit() {
}
/** 初始化事件 */
function funEventInit() {
}

// #endregion

// #region device

/** 判断设备类型 pc/mobile */
if (device.mobile()) {
    var str = location.href.toLowerCase();
    if (str.indexOf('home') >= 0) {
        location.href = datas.cc.defaut.index.h5;
    }
}
else {
    var str = location.href.toLowerCase();
    if (str.indexOf('home') < 0) {
        location.href = datas.cc.defaut.index.pc;
    }
}

// #endregion

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