
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
        imgs: [
            {
                url: 'http://www.manshijian.com/articles/article_detail/197051.html',
                text: 'Gregory Thielker：宛若油画',
                img: 'http://img2.manshijian.com/upload/banner/C9F0F895FB98AB9159F51FD0297E236D.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/197285.html',
                text: '羡慕哭了！杭州农村回迁房惊呆网友：这才是水墨江南，简直住进了吴冠中的画里啊',
                img: 'http://img2.manshijian.com/upload/banner/C4CA4238A0B923820DCC509A6F75849B.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/197149.html',
                text: '民国江湖中，梁实秋与其他“超级英雄”们是如何过招的？',
                img: 'http://img2.manshijian.com/upload/banner/C81E728D9D4C2F636F067F89CC14862C.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/196504.html',
                text: '他开了一家书店，引爆了这个城市的黑夜',
                img: 'http://img2.manshijian.com/upload/banner/ECCBC87E4B5CE2FE28308FD9F2A7BAF3.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/196326.html',
                text: '28岁的他粉丝百万，不靠脸不炫富，只靠他想过自己喜欢的生活',
                img: 'http://img2.manshijian.com/upload/banner/A87FF679A2F3E71D9181A67B7542122C.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/196542.html',
                text: '脆皮小蛋糕',
                img: 'http://img2.manshijian.com/upload/banner/E4DA3B7FBBCE2345D7772B0674A318D5.jpg'
            },
            {
                url: 'http://www.manshijian.com/articles/article_detail/196471.html',
                text: '3年走过23个国家，一个人在路上拍大片，她是自己的模特也是自己的摄影师',
                img: 'http://img2.manshijian.com/upload/banner/1679091C5A880FAF6FB5E6087EB1B2DC.jpg'
            },
            {
                url: 'http://www.manshijian.com/online/online_detail/997.html',
                text: '哪句话，曾经瞬间 直击你的心灵',
                img: 'http://img2.manshijian.com/upload/banner/8F14E45FCEEA167A5A36DEDD4BEA2543.jpg'
            }
        ],
        list: []
    }
};

// #endregion

// #region Index

app.controller("IndexController", ['$scope', function ($scope) {
    $scope.data = data.Index;
}]);

// #endregion