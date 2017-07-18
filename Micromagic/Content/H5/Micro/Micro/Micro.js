
// #region Common

/** 初始化数据 */
function funDataInit() {
}
/** 初始化事件 */
function funEventInit() {
}

// #endregion

// #region Data

/** 数据 */
var data = {
    Index: {
        time: {
            url: '',
            text: '时间',
            icon: '',
            sub: '',
            tag: '0'
        },
        phone: {
            url: '',
            text: '电话',
            icon: 'phone',
            sub: '',
            tag: '5'
        },
        message: {
            url: '',
            text: '短信',
            icon: 'message',
            sub: '',
            tag: '10'
        },
        weather: {
            url: '',
            text: '天气',
            icon: 'cloud',
            sub: '',
            tag: '0'
        },
        calendar: {
            url: '',
            text: '日历',
            icon: '',// 'date_range',
            sub: '',
            tag: '0'
        },
        email: {
            url: '',
            text: '邮件',
            icon: 'email',
            sub: '',
            tag: '0'
        },
        music: {
            url: '',
            text: '音乐',
            icon: 'music_note',
            sub: '',
            tag: '0'
        },
        video: {
            url: '',
            text: '视频',
            icon: 'videocam',
            sub: '',
            tag: '0'
        },
        photo: {
            url: '',
            text: '图片',
            icon: 'photo',
            sub: '',
            tag: '0'
        },
        camera: {
            url: '',
            text: '相机',
            icon: 'photo_camera',
            sub: '',
            tag: '0'
        },
        edge: {
            url: '',
            text: '浏览器',
            icon: 'explore',
            sub: '',
            tag: '0'
        },
        pay: {
            url: '',
            text: '支付',
            icon: 'payment',
            sub: '',
            tag: '0'
        },
        mall: {
            url: '',
            text: '商城',
            icon: 'local_mall',
            sub: '',
            tag: '0'
        },
        game: {
            url: '',
            text: '游戏',
            icon: 'videogame_asset',
            sub: '',
            tag: '0'
        },
        store: {
            url: '',
            text: '应用商店',
            icon: 'apps',
            sub: '',
            tag: '0'
        },
        magazine: {
            url: '',
            text: '杂志',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        news: {
            url: '',
            text: '新闻',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        memo: {
            url: '',
            text: '备忘录',
            icon: 'assignment',
            sub: '',
            tag: '0'
        },
        notice: {
            url: '',
            text: '消息',
            icon: 'notifications',
            sub: '',
            tag: '0'
        },
        internet: {
            url: '',
            text: 'Internet',
            icon: 'work',
            sub: '',
            tag: '0'
        },
        chattim: {
            url: '',
            text: 'QQ',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        blogtim: {
            url: '',
            text: 'WeChat',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        chathit: {
            url: '',
            text: 'Facebook',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        bloghit: {
            url: '',
            text: 'Twitter',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        office: {
            url: '',
            text: 'Office',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        word: {
            url: '',
            text: 'word',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        excel: {
            url: '',
            text: 'excel',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        ppt: {
            url: '',
            text: 'ppt',
            icon: 'book',
            sub: '',
            tag: '0'
        },
        list: []
    }
};

// #endregion

// #region Index

app.controller("IndexController", ['$scope', function ($scope) {
    $scope.data = data.Index;

    // #region 时间

    var time = new Date();
    data.Index.time.sub = funDateFormat(time, 'HH:mm');

    // #endregion

    // #region 天气

    var date = new Date();
    data.Index.calendar.sub = funDateFormat(date, 'MM月dd日');


    // #endregion

    // #region 日期



    // #endregion

    $('.ui-nav-top, .ui-nav-bottom').addClass('hidden');
}]);

// #endregion