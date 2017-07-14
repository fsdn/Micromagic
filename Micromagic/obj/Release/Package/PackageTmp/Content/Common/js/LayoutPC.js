

// #region angular

app.controller("HeaderController", ['$scope', function ($scope) {
    $scope.navs = datas.pc.nav.top;
}]);

app.controller("FooterController", ['$scope', function ($scope) {
    $scope.navs = datas.pc.nav.bottom;
    var copy = $scope.navs.copy;

    // #region 转换CopyTime
    var start = copy.startYear;
    var end = copy.endYear;
    if (start == end) {
        copy.copyYear = end;
    }
    else {
        copy.copyYear = start + ' - ' + curr;
    }

    // #endregion
}]);

// #endregion

// #region console

//调用日志打印
var logArr = datas.cc.arr.log;
for (var i in logArr) {
    var logStr = logArr[i];
    if (i == 0) {
        funLog(logStr);
    }
    else {
        funLog(logStr, 'color:red', 'color:black');
    }
}

// #endregion