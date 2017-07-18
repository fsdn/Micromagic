
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
function funMobileOrPC() {
    var isMobile = arguments[0];
    if (device.mobile()) {
        var str = location.href.toLowerCase();
        if (!isMobile) {
            location.href = datas.cc.defaut.index.h5;
        }
    }
    else {
        var str = location.href.toLowerCase();
        if (isMobile) {
            location.href = datas.cc.defaut.index.pc;
        }
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

//#region 验证

/** 判断是否是数字 */
function funValidIsNumber(str) {
    var reg = new RegExp('^[0-9]*$');
    return reg.test(str);

    // tip:http://blog.csdn.net/gusongbanyue/article/details/9628069
}

/** 判断是否手机设备 */
function funValidIsMobile() {
    var check = false;
    (function (a) { if (/(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows ce|xda|xiino/i.test(a) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test(a.substr(0, 4))) check = true; })(navigator.userAgent || navigator.vendor || window.opera);
    return check;
}

//#endregion 

// #endregion

// #region Url.js

/**
 * 返回url所有参数的对象
 */
function funUrlQueryObject() {
    return Url.parseQuery();
}
/**
 * 返回url指定参数的值
 */
function funUrlQueryString(name) {
    return Url.queryString(name);
}

// #endregion

// #region Date

/**
 * 格式化日期，指定返回字符串格式
 */
function funDateFormat(date, fmt) {
    var self = date;
    var O = {
        "M+": self.getMonth() + 1,                 //月份   
        "d+": self.getDate(),                    //日   
        "H+": self.getHours(),                   //小时   
        "h+": self.getHours(),                   //小时   
        "m+": self.getMinutes(),                 //分   
        "s+": self.getSeconds(),                 //秒   
        "q+": Math.floor((self.getMonth() + 3) / 3), //季度   
        "S": self.getMilliseconds()             //毫秒   
    };
    if (/(y+)/.test(fmt))
        fmt = fmt.replace(RegExp.$1, (self.getFullYear() + "").substr(4 - RegExp.$1.length));
    for (var K in O)
        if (new RegExp("(" + K + ")").test(fmt))
            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (O[K]) : (("00" + O[K]).substr(("" + O[K]).length)));
    return fmt;

    ////// 对Date的扩展，将 Date 转化为指定格式的String   
    ////// 月(M)、日(d)、小时(h)、分(m)、秒(s)、季度(q) 可以用 1-2 个占位符，   
    ////// 年(y)可以用 1-4 个占位符，毫秒(S)只能用 1 个占位符(是 1-3 位的数字)   
    ////// 例子：   
    ////// (new Date()).Format("yyyy-MM-dd hh:mm:ss.S") ==> 2006-07-02 08:09:04.423   
    ////// (new Date()).Format("yyyy-M-d h:m:s.S")      ==> 2006-7-2 8:9:4.18   
    ////Date.prototype.Format = function (fmt) { //author: meizz   
    ////    var o = {
    ////        "M+": this.getMonth() + 1,                 //月份   
    ////        "d+": this.getDate(),                    //日   
    ////        "h+": this.getHours(),                   //小时   
    ////        "m+": this.getMinutes(),                 //分   
    ////        "s+": this.getSeconds(),                 //秒   
    ////        "q+": Math.floor((this.getMonth() + 3) / 3), //季度   
    ////        "S": this.getMilliseconds()             //毫秒   
    ////    };
    ////    if (/(y+)/.test(fmt))
    ////        fmt = fmt.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    ////    for (var k in o)
    ////        if (new RegExp("(" + k + ")").test(fmt))
    ////            fmt = fmt.replace(RegExp.$1, (RegExp.$1.length == 1) ? (o[k]) : (("00" + o[k]).substr(("" + o[k]).length)));
    ////    return fmt;
    ////}
}

// #endregion

// #region form

/**
 * 隐式模拟提交Form
 */
function funSubmitFormHidden(url, json) {
    funSubmitForm(url, json, '_top');
}

/**
 * 隐式提交Form
 * 
 * target:
 *  _blank -- 在新窗口中打开链接 
 *  _parent -- 在父窗体中打开链接 
 *  _self -- 在当前窗体打开链接,此为默认值 
 *  _top -- 在当前窗体打开链接，并替换当前的整个窗体(框架页) 
 */
function funSubmitForm(url, json, target) {
    var form = document.createElement("form");
    document.body.appendChild(form);
    form.method = 'post';
    form.action = url;
    form.target = '_self';
    if (target) {
        form.target = target;
    }

    var put1 = document.createElement("input");
    put1.setAttribute("name", "jsonData");
    put1.setAttribute("type", "hidden");
    put1.setAttribute("value", json);
    form.appendChild(put1);

    form.submit();
}

// #endregion