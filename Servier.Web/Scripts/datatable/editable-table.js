var EditableTable = function () {
	return {
		//main function to initiate the module
		init : function () {
			var objTable = $('.edittable-datalist');
			var oTable = objTable.dataTable({
				"aaSorting"      : [[0, "desc"]],
				"aLengthMenu"    : [
					[5, 15, 20, -1],
					[5, 15, 20, "All"] // change per page values here
				],
				// set the initial value
				"iDisplayLength" : 5,
				"sDom"           : "<'row'<'col-lg-6'l><'col-lg-6'f>r>t<'row'<'col-lg-6'i><'col-lg-6'p>>",
				"sPaginationType": "bootstrap",
				"oLanguage"      : {
					"sLengthMenu": "_MENU_ records per page",
					"oPaginate"  : {
						"sPrevious": "Prev",
						"sNext"    : "Next"
					}
				},
				"aoColumnDefs"   : [
					{
						'bSortable': false,
						'aTargets' : ['sorting_disabled']
					}
				]
			});

			objTable.find('a.delete').live('click', function (e) {
				e.preventDefault();

				if (confirm("Are you sure to delete this row ?") == false) {
					return;
				}

				var nRow = $(this).parents('tr')[0];
				oTable.fnDeleteRow(nRow);
			});
		},
		group: function () {
			var objTable = $('.edittable-datalist');
			var nCloneTh = document.createElement('th');
			var nCloneTd = document.createElement('td');
			var subCloneTd = document.createElement('td');
			nCloneTd.innerHTML = '<img src="assets/images/datatable/details_close.png" class="open">';
			nCloneTd.className = "center";

			objTable.find('thead tr').each(function () {
				this.insertBefore(nCloneTh, this.childNodes[0]);
			});

			objTable.find('tbody tr').each(function () {
				if ($(this).hasClass('group-parent')) {
					this.insertBefore(nCloneTd.cloneNode(true), this.childNodes[0]);
				}
				else {
					this.insertBefore(subCloneTd.cloneNode(true), this.childNodes[0]);
				}
			});

			var oTable = objTable.dataTable({
				"bFilter"       : false,
				"bLengthChange" : false,
				"bSort"         : false,
				"bPaginate"     : false,
				"bInfo"         : false,
				"headerCallback": function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
					if ($('.advance-form').length > 0) {
						$('.group-head').each(function (index) {
							if (index == 0) {
								$(this).children('th:first-child').remove();
								$(this).children('th:first-child').attr({
									'colspan': 2,
									'rowspan': 2
								});
							}
							else {
								$(this).find('th').each(function () {
									if ($(this).is(':empty')) {
										$(this).remove();
									}
								});
							}
						});
					}
					else {
						$(nRow).children('th:first-child').remove();
						$(nRow).children('th:first-child').attr('colspan', 2);
					}
				},
				"fnRowCallback" : function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
					if (!$(nRow).hasClass('group-parent')) {
						$(nRow).children('td:first-child').remove();
						$(nRow).children('td:first-child').attr('colspan', 2);
					}
				}
			});

			// show group when clicking icon
			objTable.find('tbody td img').live('click', function () {
				var nTr = $(this).parents('tr')[0];
				var clsGroup = '.' + $(nTr).attr('id');

				if ($(this).hasClass('open')) {
					$(this).removeClass('open').attr('src', 'assets/images/datatable/details_open.png');
					$(clsGroup).each(function () {
						$(this).addClass('group-sub');
					});

				}
				else {
					$(this).addClass('open').attr('src', 'assets/images/datatable/details_close.png');
					$(clsGroup).each(function () {
						$(this).removeClass('group-sub');
					});
				}
			});
		}
	};
}(jQuery);