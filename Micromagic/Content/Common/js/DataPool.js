// #region 数据清单

/**
 * datas：数据最高对象
 * 
 * datas.cc：公共数据
 * 
 * 
 * datas.h5：H5页面数据
 * 
 * 
 * 
 * datas.pc：PC页面数据
 */

// #endregion

// #region datas

var datas = {};

// #endregion

// #region datas.cc

/** 公共数据 */
datas.cc = {};

/** 公共数据联系人 */
datas.cc.acter = {};
datas.cc.acter.qq = '1296696830';
datas.cc.acter.email = '1296696830@qq.com';

/** 公共数据字符串 */
datas.cc.str = {};
datas.cc.str.brand = '慢时间';

/** 公共数组字符串 */
datas.cc.arr = {};
datas.cc.arr.log = [
'天将降大任于斯人也，\n必先卸其QQ，\n封其微博，\n删其微信，\n去其贴吧，\n收其电脑，\n夺其手机，\n摔其ipad，\n断其wifi，\n剪其网线，\n使其百无聊赖，\n然后静坐、喝茶、思过、锻炼、读书、弹琴、练字、明智、开悟、精进，\n而后必成大器也！',
'邮箱 %c' + datas.cc.acter.email + ' %c 闲人免扰，谢谢！'
];

// #endregion

// #region datas.h5

datas.h5 = {};

// #endregion

// #region datas.pc

datas.pc = {};
/** 导航数据 */
datas.pc.nav = {
    top: {
        brand: {
            url: '/',
            text: datas.cc.str.brand,
            list: []
        },
        list: [
            {
                url: 'http://www.manshijian.com/articles/category/manshenghuo.html',
                text: '慢生活',
                list: [
                    {
                        url: 'http://www.manshijian.com/articles/category/shougong.html',
                        text: '手工'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/jiaju.html',
                        text: '家居'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/meishi.html',
                        text: '美食'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/huacao.html',
                        text: '花草'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/chuangyi.html',
                        text: '创意'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/fengshang.html',
                        text: '风尚'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/mengchong.html',
                        text: '萌宠'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/jiankang.html',
                        text: '健康'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/jiaoyu.html',
                        text: '教育'
                    }
                ]
            },
            {
                url: 'http://www.manshijian.com/gongyi.html',
                text: '慢公益',
                list: []
            },
            {
                url: 'http://www.manshijian.com/articles/category/manyizu.html',
                text: '慢一族',
                list: [
                     {
                         url: 'http://www.manshijian.com/articles/category/lvxingzhe.html',
                         text: '驴行者'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/sheyingren.html',
                         text: '摄影人'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/tamen.html',
                         text: '她们'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/yishuzhe.html',
                         text: '艺术者'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/mingxing.html',
                         text: '名人'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/shougongke.html',
                         text: '手工客'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/meishijia.html',
                         text: '美食家'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/zaomengzhe.html',
                         text: '造梦者'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/manyou.html',
                         text: '慢友'
                     }
                ]
            },
            {
                url: 'http://www.manshijian.com/articles/category/manfengjing.html',
                text: '慢风景',
                list: [
                     {
                         url: 'http://www.manshijian.com/articles/category/lvxing.html',
                         text: '旅行'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/sheying.html',
                         text: '摄影'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/kezhan.html',
                         text: '客栈'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/cunluo.html',
                         text: '村落'
                     },
                     {
                         url: 'http://www.manshijian.com/articles/category/xiaodian.html',
                         text: '小店'
                     }
                ]
            },
            {
                url: 'http://www.manshijian.com/articles/category/manwenyi.html',
                text: '慢文艺',
                list: [
                    {
                        url: 'http://www.manshijian.com/articles/category/dianying.html',
                        text: '电影'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/yinyue.html',
                        text: '音乐'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/xiju.html',
                        text: '戏剧'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/yuedu.html',
                        text: '阅读'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/suibi.html',
                        text: '随笔'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/chahua.html',
                        text: '插画'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/category/dongman.html',
                        text: '动漫'
                    }
                ]
            },
            {
                url: 'http://www.manshijian.com/online/party_new_list.html',
                text: '慢活动',
                list: [
                    {
                        url: 'http://www.manshijian.com/online/online_list/new.html',
                        text: '话题慢聊'
                    },
                    {
                        url: 'http://www.manshijian.com/parties/party_list/new.html',
                        text: '活动推荐'
                    }
                ]
            },
            {
                url: 'http://www.manshijian.com/manjishi.html',
                text: '慢集市',
                list: []
            },
            {
                url: 'javascript:void(0);',
                text: '慢应用',
                list: [
                    {
                        url: 'http://www.manshijian.com/manxialai.html',
                        text: '慢下来'
                    },
                    {
                        url: 'http://www.manshijian.com/topic/topic_list.html',
                        text: '慢专题'
                    },
                    {
                        url: 'http://www.manshijian.com/manhuamian.html',
                        text: '慢画面'
                    }
                ]
            },
            {
                url: 'http://www.manshijian.com/topic/topic_detail/shijianmandi.html',
                text: '慢递',
                list: [
                    {
                        url: 'http://www.manshijian.com/topic/topic_detail/shijianmandi.html',
                        text: '慢递小店'
                    },
                    {
                        url: 'http://www.manshijian.com/articles/article_detail/152771.html',
                        text: '甜品工房'
                    },
                    {
                        url: 'http://www.manshijian.com/mandi.html',
                        text: '线上慢递'
                    },
                    {
                        url: 'http://www.manshijian.com/mandi_search.html',
                        text: '慢递查询'
                    }
                ]
            },
            {
                url: 'http://www.manshijian.com/faxian.html',
                text: '发现美好',
                list: []
            }
        ]
    },
    bottom: {
        copy: {
            brand: datas.cc.str.brand,
            copyright: '版权所有',// 'Copyright',
            symbol: '&copy;',//'©',
            domainName: 'magic.com',
            startYear: 2017, //-->2017-07-11
            endYear: (new Date()).getFullYear(),
            copyYear: (new Date()).getFullYear(),
            secNo: '京公网安备11010802014853',
            icpNo: '京ICP备11008151号',
            icpUrl: 'http://www.miibeian.gov.cn'
        },
        brand: {
            url: '',
            text: '我可以走得很慢，但是我绝不后退。',
            list: []
        },
        list: [
            {
                url: '',
                text: '友情链接',
                list: [
                    {
                        text: '百度传课',
                        url: 'http://www.chuanke.com/'
                    },
                    {
                        text: '慕课网',
                        url: 'http://www.imooc.com/'
                    },
                    {
                        text: '前端网',
                        url: 'http://www.w3cfuns.com/'
                    },
                    {
                        text: '慢时间',
                        url: 'http://www.manshijian.com/'
                    },
                    {
                        text: '人人都是产品经理',
                        url: 'http://www.woshipm.com/'
                    },
                    {
                        text: '在线工具',
                        url: 'http://tool.cc/'
                    }
                ]
            },
            {
                url: '',
                text: '技术酷站',
                list: [
                    {
                        text: '开源中国',
                        url: 'http://www.oschina.net/'
                    },
                    {
                        text: 'Github',
                        url: 'https://github.com/'
                    },
                    {
                        text: 'EnvatoMarket',
                        url: 'http://codecanyon.net/'
                    },
                    {
                        text: '在线工具',
                        url: 'http://tool.cc/'
                    },
                    {
                        text: '站长之家',
                        url: 'http://sc.chinaz.com/'
                    },
                    {
                        text: '懒人之家',
                        url: 'http://www.lanrenzhijia.com/'
                    },
                    {
                        text: '大头网',
                        url: 'http://www.datouwang.com/'
                    },
                    {
                        text: '科e互联',
                        url: 'http://www.internetke.com/effects/'
                    },
                    {
                        text: '源码爱好者',
                        url: 'http://www.codefans.net/'
                    },
                    {
                        text: '网页特效库',
                        url: 'http://www.5iweb.com.cn/'
                    },
                    {
                        text: 'jQuery之家',
                        url: 'http://www.htmleaf.com/'
                    },
                    {
                        text: 'JS代码网',
                        url: 'http://www.js-css.cn/'
                    },
                    {
                        text: 'RUNOOB',
                        url: 'http://www.runoob.com/'
                    }
                ]
            },
            {
                url: '',
                text: '开源技术',
                list: [
                    {
                        text: '阿里巴巴',
                        url: 'http://www.oschina.net/project/alibaba'
                    },
                    {
                        text: '百度',
                        url: 'http://www.oschina.net/project/baidu'
                    },
                    {
                        text: '腾讯',
                        url: 'http://www.oschina.net/project/tencent'
                    },
                    {
                        text: '网易',
                        url: 'http://www.oschina.net/project/netease'
                    },
                    {
                        text: '豆瓣',
                        url: 'http://www.oschina.net/project/douban'
                    },
                    {
                        text: '新浪',
                        url: 'http://www.oschina.net/project/sina'
                    },
                    {
                        text: '深度Deepin',
                        url: 'http://www.oschina.net/project/deepin'
                    },
                    {
                        text: '58同城',
                        url: 'http://www.oschina.net/project/58'
                    },
                    {
                        text: '大众点评',
                        url: 'http://www.oschina.net/project/dianping'
                    },
                    {
                        text: '搜狐',
                        url: 'http://www.oschina.net/project/sohu'
                    },
                    {
                        text: '小米',
                        url: 'http://www.oschina.net/project/xiaomi'
                    },
                    {
                        text: '豌豆荚',
                        url: 'http://www.oschina.net/project/wandoujia'
                    },
                    {
                        text: '金山',
                        url: 'http://www.oschina.net/project/kingsoft'
                    },
                    {
                        text: '华为',
                        url: 'http://www.oschina.net/project/huawei'
                    },
                    {
                        text: '东软',
                        url: 'http://www.oschina.net/project/neusoft'
                    },
                    {
                        text: '360',
                        url: 'http://www.oschina.net/project/360'
                    },
                    {
                        text: '禅道',
                        url: 'http://www.oschina.net/project/zentao'
                    },
                    {
                        text: '开源中国',
                        url: 'http://www.oschina.net/project/osc'
                    },
                    {
                        text: 'Apache 基金会',
                        url: 'http://www.oschina.net/project/apache'
                    },
                    {
                        text: 'JBoss',
                        url: 'http://www.oschina.net/project/jboss'
                    },
                    {
                        text: 'Google',
                        url: 'http://www.oschina.net/project/google'
                    },
                    {
                        text: 'Mozilla',
                        url: 'http://www.oschina.net/project/mozilla'
                    },
                    {
                        text: 'Facebook',
                        url: 'http://www.oschina.net/project/facebook'
                    },
                    {
                        text: '微软',
                        url: 'http://www.oschina.net/project/microsoft'
                    },
                    {
                        text: 'Netflix',
                        url: 'http://www.oschina.net/project/netflix'
                    },
                    {
                        text: 'Twitter',
                        url: 'http://www.oschina.net/project/twitter'
                    },
                    {
                        text: 'NASA',
                        url: 'http://www.oschina.net/project/nasa'
                    },
                    {
                        text: 'Github',
                        url: 'http://www.oschina.net/project/github'
                    },
                    {
                        text: 'Paypal',
                        url: 'http://www.oschina.net/project/paypal'
                    }
                ]
            },
            {
                url: '',
                text: 'UI设计',
                list: [
                    {
                        text: 'UI中国',
                        url: 'http://www.ui.cn/'
                    },
                    {
                        text: '盒子UI',
                        url: 'http://www.boxui.com/'
                    },
                    {
                        text: 'Uimaker',
                        url: 'http://www.uimaker.com/'
                    },
                    {
                        text: '学UI网',
                        url: 'http://www.xueui.cn/'
                    },
                    {
                        text: 'UI社',
                        url: 'http://www.uishe.cn/'
                    },
                    {
                        text: 'UI设计网',
                        url: 'http://www.uisheji.com/'
                    },
                    {
                        text: 'UI63',
                        url: 'http://ui63.com/'
                    },
                    {
                        text: '优艾图',
                        url: 'http://www.uiimg.com/'
                    }
                ]
            },
            {
                url: '',
                text: '矢量图标',
                list: [
                    {
                        text: '阿里巴巴矢量图标库',
                        url: 'http://www.iconfont.cn/'
                    },
                    {
                        text: 'FontAwesome',
                        url: 'http://fontawesome.io/'
                    },
                    {
                        text: 'Glyphicons',
                        url: 'http://glyphicons.com/'
                    },
                    {
                        text: 'Iconfinder',
                        url: 'https://www.iconfinder.com/'
                    },
                    {
                        text: 'Flaticon',
                        url: 'http://www.flaticon.com/'
                    },
                    {
                        text: 'Dryicons',
                        url: 'http://dryicons.com/'
                    },
                    {
                        text: 'Findicons',
                        url: 'http://findicons.com/'
                    },
                    {
                        text: 'Easyicon',
                        url: 'http://www.easyicon.net/'
                    },
                    {
                        text: 'Iconarchive',
                        url: 'http://www.iconarchive.com/'
                    },
                    {
                        text: 'Softicons',
                        url: 'http://www.softicons.com/'
                    },
                    {
                        text: 'Iconpng',
                        url: 'http://www.iconpng.com/'
                    },
                    {
                        text: 'Icons8',
                        url: 'https://icons8.com/'
                    },
                    {
                        text: 'Dryicons',
                        url: 'http://dryicons.com/'
                    }
                ]
            },
            {
                url: '',
                text: 'H5特效',
                list: [
                    {
                        text: '场景应用',
                        url: 'http://www.liveapp.cn/'
                    },
                    {
                        text: 'MAKA',
                        url: 'http://www.maka.im/'
                    },
                    {
                        text: 'Html5Tricks',
                        url: 'http://www.html5tricks.com/'
                    },
                    {
                        text: '17素材',
                        url: 'http://www.17sucai.com/'
                    }
                ]
            }
        ],
        expand: [
            {
                url: '',
                text: '资源酷站',
                list: [
                    {
                        text: '神算堂',
                        url: 'http://m.shensuantang.com/'
                    }
                ]
            }
        ]
    }
};

// #endregion