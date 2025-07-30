// File Upload Component
// options:
// - DropFilesPrompt (string)
// - ChooseFilePrompt (string)
// - Accept (string)
// - Multiple (boolean)
// - UseSorting (boolean)
// - MaximumUploadFiles (number)
// - FileWrongTypeMessage (string)
// - FileAmountMessage (string)
// - FileSelectMessage (string)
// - UploadOptions (array of sting) e.g ['DOCX', 'DOC', ...]
// - ApiBasePath (string)
// - Method (callback)
// - UploadAndRedirect (boolean)
// - showAlert (function (string) => void)
// - hideAlert (function () => void)
// - showLoader (function () => void)
// - progress (function () => void)


(function ($) {
	$.fn.filedrop = function (options, id) {

		var googleDriveOAuthToken = null;

		/*var getRandomIntInclusive = function (min, max) {
			min = Math.ceil(min);
			max = Math.floor(max);
			return Math.floor(Math.random() * (max - min + 1)) + min;
		};

		var randomId = getRandomIntInclusive(1, Number.MAX_SAFE_INTEGER);*/

		// callbacks
		var onUploadCallback = null;
		var onRemoveCallback = null;

		var randomId = id;
		var acceptExts = options.Accept.split(/\s*,\s*/).map(function (ext) {
			return ext.substring(1).toUpperCase();
		});

		var droppedFiles = [];

		var getFileExtension = function (file) {
			var pos = file.name.lastIndexOf(".");
			return pos !== -1 ? file.name.substring(pos + 1).toUpperCase() : null;
		};

		var nextFileId = function () {
			var id = 1;
			var found;
			do {
				found = false;
				for (let i = 0; i < droppedFiles.length; i++) {
					if (droppedFiles[i].id === id) {
						id += 1;
						found = true;
						break;
					}
				}
			} while (found);
			return id;
		};

		var preventFileDrop = function (evt) {
			evt = evt || event;
			evt.preventDefault();
			evt.stopPropagation();
		};

		var removeFileBlock = function (id) {
			var pos;
			for (pos = 0; pos < droppedFiles.length; pos++) {
				if (droppedFiles[pos].id === id) {
					break;
				}
			}
			if (pos < droppedFiles.length) {
				if (onRemoveCallback !== null) {
					onRemoveCallback(droppedFiles[pos]);
				}

				droppedFiles.splice(pos, 1);
				$("#filedrop-" + randomId).find("#fileupload-" + id).remove();

				var curCount = parseInt($("#count1").html()) - 1;
				$("#count1").html(curCount);
				$("#count2").html(curCount);

				/*
				if (droppedFiles.length === 0) { // the last file was removed
					$("#filedrop-" + randomId).find(".chooseFilesLabel").removeClass("d-none");
				}
				*/
			}
		};

		var removeAllFileBlocks = function () {

			for (var pos = 0; pos < droppedFiles.length; pos++) {
				
				var id = droppedFiles[pos].id;

				if (onRemoveCallback !== null) {
					onRemoveCallback(droppedFiles[pos]);
				}
				
				$("#filedrop-" + randomId).find("#fileupload-" + id).remove();
			}

			droppedFiles.splice(0, droppedFiles.length);			

			$("#count1").html(0);
			$("#count2").html(0);
		};

		var moveUpFileBlock = function (id) {
			var pos;
			for (pos = 0; pos < droppedFiles.length; pos++) {
				if (droppedFiles[pos].id === id) {
					break;
				}
			}
			if (pos < droppedFiles.length && pos !== 0) {
				var prevId = droppedFiles[pos - 1].id;
				var flTemp = droppedFiles[pos - 1];
				droppedFiles[pos - 1] = droppedFiles[pos];
				droppedFiles[pos] = flTemp;

				var block = $("#filedrop-" + randomId + " > #fileupload-" + id).detach();
				$("#filedrop-" + randomId + " > #fileupload-" + prevId).before(block);
			}
		};

		var moveDownFileBlock = function (id) {
			var pos;
			for (pos = 0; pos < droppedFiles.length; pos++) {
				if (droppedFiles[pos].id === id) {
					break;
				}
			}
			if (pos < droppedFiles.length && pos !== (droppedFiles.length - 1)) {
				var nextId = droppedFiles[pos + 1].id;
				var flTemp = droppedFiles[pos + 1];
				droppedFiles[pos + 1] = droppedFiles[pos];
				droppedFiles[pos] = flTemp;

				var block = $("#filedrop-" + randomId + " > #fileupload-" + id).detach();
				$("#filedrop-" + randomId + " > #fileupload-" + nextId).after(block);
			}
		};

		var appendFileBlock = function (file) {
			var id = nextFileId();
			var name = file.name;

			if (typeof file === 'string' || file instanceof String) {
				var pos = file.lastIndexOf("/");
				name = pos !== -1 ? file.substring(pos + 1) : null;
			}

			var size = '';
			var fileSize = file.size;
			if (file.size == undefined) {
				fileSize = file.bytes;
			}

			if (fileSize != undefined) {
				size = (Number.parseFloat((fileSize / 1024)).toFixed(2)) + ' KB';

				if (fileSize > 104858) {
					size = (Number.parseFloat((fileSize / 1024 / 1024)).toFixed(2)) + ' MB';
				}
			}

			var fileMoveUpLink = null;
			var fileMoveDownLink = null;
			if (options.UseSorting) {
				fileMoveUpLink = $('\
                    <span class="fileMoveUpLink">\
                        <i class="fas fa-arrow-up"></i>\
                    </span>\
                ');
				fileMoveDownLink = $('\
                    <span class="fileMoveDownLink">\
                        <i class="fas fa-arrow-down"></i>\
                    </span>\
                ');
				fileMoveUpLink.on("click",
					function () {
						moveUpFileBlock(id);
					});
				fileMoveDownLink.on("click",
					function () {
						moveDownFileBlock(id);
					});
			}
			var fileRemoveLink = $('<i class="bi bi-trash"></i>');
			fileRemoveLink.on("click",
				function () {
					removeFileBlock(id);
				});

			var fileRemoveATag = $('<a href="#" data-bs-toggle="tooltip" data-bs-placement="bottom" title="' + o.RemoveText + '"></a>');
			var fileRemoveDivTag = $('<div class="fileoptions text-end"></div>');
			fileRemoveATag.append(fileRemoveLink);
			fileRemoveDivTag.append(fileRemoveATag);

			var fileImageTag = $('<div class="imagetag"><img src="https://products.fileformat.ai/fileformat/common/img/imagepdf.png" alt="fileuploaded" width="48" height="48"></div>');
			var fileSortTag = $('<div class="sortingtag"><i class="bi bi-grip-vertical"></i></div>');


			var spanFileName = $('<div class="titletag">' + name + ' <span>' + size + '</span></div>');
			var fileBlock = $('<div id="fileupload-' + id + '" class="filebar" data-item-sortable-id="0" draggable="true" role="option" aria-grabbed="false">');
			fileBlock.on("dragover", preventFileDrop);
			fileBlock.on("drop", preventFileDrop);

			fileBlock.append(fileSortTag);
			fileBlock.append(fileImageTag);
			fileBlock.append(spanFileName);

			if (fileMoveUpLink !== null && fileMoveDownLink !== null) {
				fileBlock.append(fileMoveUpLink);
				fileBlock.append(fileMoveDownLink);
			}
			fileBlock.append(fileRemoveDivTag);

			$("#filedrop-" + randomId).append(fileBlock);

			var curCount = parseInt($("#count1").html()) + 1;
			$("#count1").html(curCount);
			$("#count2").html(curCount);			

			showSideBar();

			droppedFiles.push({
				id,
				file,
				name
			});
		};

		var addFilesToFormData = function (data) {
			var dotPos, ext;
			var f;
			for (let i = 0; i < droppedFiles.length; i++) {
				f = droppedFiles[i];
				dotPos = f.name.lastIndexOf(".");
				ext = dotPos >= 0 ? f.name.substring(dotPos + 1).toUpperCase() : null;
				if (ext !== null && options.UploadOptions.indexOf(ext) !== -1) {

					if (f.file != null && (typeof f.file === 'string' || f.file instanceof String)) {

						var blob = new Blob([f.file], { type: "text/xml" });
						data.append(f.id, blob, f.name + '-url');
					}
					else if (f.file.link != null) {

						var blob = new Blob([f.file.link], { type: "text/xml" });
						data.append(f.id, blob, f.name + '-url');
					}
					else if (f.file.url != null) {

						var blob = new Blob([f.file.id + " " + googleDriveOAuthToken], { type: "text/xml" });						
						data.append(f.id, blob, f.name + '-id');
					}
					else
					{
						data.append(f.id, f.file, f.name);
					}
					
				} else {
					options.showAlert(options.FileWrongTypeMessage + ext);
					return null;
				}
			}
		};

		var prepareFormData = function (min = 1, max = undefined) {
			if (max === undefined)
				max = options.MaximumUploadFiles;

			if (droppedFiles.length) {
				if (droppedFiles.length < min || droppedFiles.length > max) {
					options.showAlert(options.FileAmountMessage);
					return null;
				}
				const data = new FormData();
				addFilesToFormData(data);
				return data;
			} else {
				options.showAlert(options.FileSelectMessage);
				return null;
			}
		};

		var uploadGoogleDriveFiles = function (docs, token) {

			googleDriveOAuthToken = token;

			return uploadDropBoxFiles(docs);

			/*
			var bError = false;
			if (docs.length) {
				let fileCount = docs.length + droppedFiles.length;

				let archiveFiles = getArchiveFilesNumber(docs);
				if (archiveFiles > 1 || archiveFiles === 1 && fileCount - 1 > 0) {
					bError = true;
					options.showAlert(options.OnlyOneArchiveFile);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				} else if (fileCount <= options.MaximumUploadFiles) {					

					var ext;
					options.hideAlert();
					docs_max = [];
					for (var i = 0; i < docs.length; i++) {
						let f = docs[i];
						ext = getFileExtension(f);
						if (ext !== null && acceptExts.indexOf(ext) !== -1 || ext === "GZ") {
							if (f.bytes > options.MaximumUploadSize) {
								docs_max.push(f.name);
							} else {
								appendFileBlock(f);
							}
						} else {
							bError = true;
							if (ext !== null)
								ext = ext.toUpperCase();
							options.showAlert(options.FileWrongTypeMessage + ext);
						}
					}
					if (docs_max.length > 0) {
						bError = true;
						options.showAlert(options.MaximumUploadSizeMessage + docs_max.join(", "));
					}
				} else {
					bError = true;
					options.showAlert(options.FileAmountMessage);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				}

				if (onUploadCallback !== null) {
					onUploadCallback(event.target.docs);
				}
			}

			return !bError;
			*/
		};

		var uploadDropBoxFiles = function (files) {
			var bError = false;
			if (files.length) {
				let fileCount = files.length + droppedFiles.length;

				let archiveFiles = getArchiveFilesNumber(files);
				if (archiveFiles > 1 || archiveFiles === 1 && fileCount - 1 > 0) {
					bError = true;
					options.showAlert(options.OnlyOneArchiveFile);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				} else if (fileCount <= options.MaximumUploadFiles) {

					var ext;
					options.hideAlert();
					files_max = [];
					for (var i = 0; i < files.length; i++) {
						let f = files[i];
						ext = getFileExtension(f);
						if (ext !== null && acceptExts.indexOf(ext) !== -1 || ext === "GZ") {
							if (f.bytes > options.MaximumUploadSize) {
								 files_max.push(f.name);								
							} else {
								appendFileBlock(f);
							}
						} else {
							bError = true;
							if (ext !== null)
								ext = ext.toUpperCase();
							options.showAlert(options.FileWrongTypeMessage + ext);
						}
					}
					if (files_max.length > 0) {
						bError = true;
						options.showAlert(options.MaximumUploadSizeMessage + files_max.join(", "));
					}
				} else {
					bError = true;
					options.showAlert(options.FileAmountMessage);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				}

				if (onUploadCallback !== null) {
					onUploadCallback(event.target.files);
				}
			}

			return !bError;
		};

		function isValidHttpUrl(string) {
			let url;

			try {
				url = new URL(string);
			} catch (_) {
				return false;
			}

			return url.protocol === "http:" || url.protocol === "https:";
		}

		function selectSideUrl() {

			var url = $("#sideUrl").val();

			if (!url || !isValidHttpUrl(url)) {
				window.alert(options.MsgUrlValidationText);
				return;
			}

			uploadUrlFile(url);

			$("#sidelinkbtn .img1").toggleClass("d-none");
			$("#sidelinkbtn .img2").toggleClass("d-none");
			$(".popover-tag-side").toggleClass("showbox");
		}

		function selectMainUrl() {

			var url = $("#mainUrl").val();

			if (!url || !isValidHttpUrl(url)) {
				window.alert(options.MsgUrlValidationText);
				return;
			}

			uploadUrlFile(url);

			$("#main-uplink .img1").toggleClass("d-none");
			$("#main-uplink .img2").toggleClass("d-none");
			$("#uploadfilepath").toggleClass("showbox");
		}

		var uploadUrlFile = function (url) {
			var bError = false;

			var ext;
			options.hideAlert();

			var pos = url.lastIndexOf(".");
			ext = pos !== -1 ? url.substring(pos + 1).toUpperCase() : null;


			if (ext !== null && acceptExts.indexOf(ext) !== -1 || ext === "GZ") {
				appendFileBlock(url);
			} else {
				bError = true;
				if (ext !== null)
					ext = ext.toUpperCase();
				options.showAlert(options.FileWrongTypeMessage + ext);
			}

			if (onUploadCallback !== null) {
				onUploadCallback(url);
			}

			return !bError;
		};


		function showSideBar() {

			if (!$(".sidebar-hide .bi-chevron-left").hasClass("d-none")) {

				$(".sidebar-hide .bi-chevron-left").addClass("d-none");
				$(".sidebar-hide .bi-chevron-right").removeClass("d-none");
				$(".sidesticky").toggleClass("stickyoff");
				$(".sidebarfeatures").toggleClass("slideoff");
			}
		}

		function hideSlideBar() {
			if (!$(".sidebar-hide .bi-chevron-right").hasClass("d-none")) {

				$(".sidebar-hide i.bi-chevron-right").addClass("d-none");
				$(".sidebar-hide i.bi-chevron-left").removeClass("d-none");
				$(".sidesticky").toggleClass("stickyoff");
				$(".sidebarfeatures").toggleClass("slideoff");
			}
		}

		var uploadFileSelected = function (event) {
			var bError = false;
			if (event.target.files && event.target.files.length) {
				let fileCount = event.target.files.length + droppedFiles.length;

				let archiveFiles = getArchiveFilesNumber(event.target.files);
				if (archiveFiles > 1 || archiveFiles === 1 && fileCount - 1 > 0) {
					bError = true;
					options.showAlert(options.OnlyOneArchiveFile);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				} else if (fileCount <= options.MaximumUploadFiles) {

					var ext;
					options.hideAlert();
					files_max = [];
					for (var i = 0; i < event.target.files.length; i++) {
						let f = event.target.files[i];
						ext = getFileExtension(f);
						if (ext !== null && acceptExts.indexOf(ext) !== -1 || ext === "GZ") {
							if (f.size > options.MaximumUploadSize) {
								files_max.push(f.name);
							} else {
								//$("#filedrop-" + randomId).find(".chooseFilesLabel").addClass("d-none");
								appendFileBlock(f);
							}
						} else {
							bError = true;
							if (ext !== null)
								ext = ext.toUpperCase();
							options.showAlert(options.FileWrongTypeMessage + ext);
						}
					}
					if (files_max.length > 0) {
						bError = true;
						options.showAlert(options.MaximumUploadSizeMessage + files_max.join(", "));
					}
				} else {
					bError = true;
					options.showAlert(options.FileAmountMessage);
					window.setTimeout(function () {
						options.hideAlert();
					},
						5000);
				}

				if (onUploadCallback !== null) {
					onUploadCallback(event.target.files);
				}
				// console.info('--SELECTED-->>', event.target.files); // @@@@@
			}

			// clear the file input field
			$("input#UploadFileInput" + randomId).val("");

			$("#rightpanelFileUpload").val("");
			if (!$(".dropfilebox").hasClass("d-none")) {
				$(".dropfilebox").addClass("d-none");
			}
			
			return !bError;
		};

		var uploadFileAndRedirect = function (event) {
			if (uploadFileSelected(event)) {
				var data = prepareFormData();
				if (data != undefined) {
					options.showLoader();
					options.Method();
				}
			}
		};

		/*var twoBlocks = o.AppName === "Comparison";
		var fileDropBlockStr = '\
			<div class="filedrop filedrop-mvc fileplacement ' + (twoBlocks ? 'twoblocks' : '') +' lazyload" id="filedrop-' + randomId + '"' + ' data-nosnippet>\
				<label for="UploadFileInput' + randomId + '">' + options.DropFilesPrompt + '</label>\
				<input type="file" class="uploadfileinput" id="UploadFileInput' + randomId + '" name="UploadFileInput' + randomId + '"\
					title=""\
					accept="' + options.Accept + '"' +
										(options.Multiple ? 'multiple="' + options.Multiple + '"' : '') + 
				'/>\
			</div>';

		if (twoBlocks) {
			fileDropBlockStr = '\
					<div class="col-md-6 col-sm-12">' +
						fileDropBlockStr + '\
					</div>';
		}
		var fileDropBlock = $(fileDropBlockStr);

		// adding file drop block
		this.prepend(fileDropBlock);*/

		// adding event handlers
		if (!options.UploadAndRedirect) {
			$("input#UploadFileInput" + randomId).on("change", uploadFileSelected);
			$("#rightpanelFileUpload").on("change", uploadFileSelected);
		} else {
			$("input#UploadFileInput" + randomId).on("change", uploadFileAndRedirect);
		}				

		$("#clear1").on("click", removeAllFileBlocks);
		$("#clear2").on("click", removeAllFileBlocks);
		//$('[data-toggle="tooltip"]').tooltip({
		//	trigger: 'hover'
		//})

		// return object with access fields
		return {
			get nextFileId() {
				return nextFileId;
			},
			get droppedFiles() {
				return droppedFiles;
			},
			get prepareFormData() {
				return prepareFormData;
			},
			on: function (action, callback) {
				if (typeof callback === "function") {
					if (action === "upload") {
						onUploadCallback = callback;
					} else if (action === "remove") {
						onRemoveCallback = callback;
					}
				}
			},
			off: function (action) {
				if (action === "upload") {
					onUploadCallback = null;
				} else if (action === "remove") {
					onRemoveCallback = null;
				}
			},
			addFilesToFormData: function (data) {
				return addFilesToFormData(data);
			},
			uploadDropBoxFiles: function (files) {
				return uploadDropBoxFiles(files);
			},
			uploadGoogleDriveFiles: function (docs, token) {
				return uploadGoogleDriveFiles(docs, token);
			},
			selectSideUrl: function () {
				selectSideUrl();
			},
			selectMainUrl: function () {
				selectMainUrl();
			},
			reset: function () {
				droppedFiles = [];
				$("#filedrop-" + randomId).find("div[id^=fileupload-]").remove();
				$("#filedrop-" + randomId).find(".chooseFilesLabel").removeClass("d-none");
			}
		};
	};
})(jQuery);
