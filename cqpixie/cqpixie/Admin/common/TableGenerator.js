  var lang = {
     "sProcessing": "处理中...",
     "sLengthMenu": "每页 _MENU_ 项",
     "sZeroRecords": "没有匹配结果",
     "sInfo": "当前显示第 _START_ 至 _END_ 项，共 _TOTAL_ 项。",
     "sInfoEmpty": "当前显示第 0 至 0 项，共 0 项",
     "sInfoFiltered": "(由 _MAX_ 项结果过滤)",
     "sInfoPostFix": "",
     "sSearch": "搜索:",
     "sUrl": "",
     "sEmptyTable": "没有找到数据",
     "sLoadingRecords": "载入中...",
     "sInfoThousands": ",",
     "oPaginate": {
     "sFirst": "首页",
     "sPrevious": "上页",
     "sNext": "下页",
     "sLast": "末页",
     "sJump": "跳转"
     },
     "sZeroRecords": "没有检索到数据",
     "oAria": {
       "sSortAscending": ": 以升序排列此列",
       "sSortDescending": ": 以降序排列此列"
     }
  };

var getTable = function(action, columns, pageSize){
	pageSize = pageSize || 2; // if no pageSize passed in, use default pagesize 2

  	var table = {};

  	table.language = lang;

  	table.processing = true;

  	table.serverSide = true;

  	table.lengthMenu = false;

  	table.lengthChange = false;

  	table.ordering = false;

  	table.paging = true;

  	table.pageLength = pageSize;

  	table.pagingType = "simple_numbers",//"full_numbers",

  	table.searching = false;

  	table.ajax = {
      "url": "http://localhost:32030/SL/AjaxCallHandler.ashx?action="+action,
      "type":"POST",
      // "data" is the value sent to server
      "data": function ( data ) {
        pageIndex = data.start/data.length;
        return JSON.stringify({"pagesize" : pageSize,"pageindex":pageIndex});
      },
      // "dataSrc" is the value sent by from server
      "dataSrc":function(result){
        // console.log(result);
        // console.log(result.PageIndex);
        // console.log(result.CountTotal);
        result.recordsTotal = result.CountTotal;
        result.recordsFiltered = result.CountTotal;
        return result.DataList;      
      }
  	};

  	table.columns = columns;

  	return table;
};
