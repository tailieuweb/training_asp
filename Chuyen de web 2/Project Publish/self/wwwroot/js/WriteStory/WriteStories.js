var editorContent;
var articleId = null;
const getBrowseUrl = window.location.href;
const browseUrlArr = getBrowseUrl.split("/");
const getArticleId = browseUrlArr[browseUrlArr.length - 1];
const handleEditorText = document.getElementById("handleEditorText");
var getTimeOut = null;
ClassicEditor
	.create(document.querySelector('#ckeditor'), {
		ckfinder: {
			uploadUrl: '/WriteArticle/SaveEditorImage?id=' + getArticleId
		},
		toolbar: {
			items: [
				'heading',
				'|',
				'bold',
				'italic',
				'underline',
				'link',
				'bulletedList',
				'numberedList',
				'todoList',
				'blockQuote',
				'|',
				'indent',
				'outdent',
				'fontSize',
				'fontColor',
				'fontBackgroundColor',
				'fontFamily',
				'|',
				'imageInsert',
				'mediaEmbed',
				'insertTable',
				'highlight',
				'undo',
				'redo'
			]
		},
		language: 'en',
		image: {
			toolbar: [
				'imageTextAlternative',
				'imageStyle:full',
				'imageStyle:side',
				'linkImage'
			]
		},
		table: {
			contentToolbar: [
				'tableColumn',
				'tableRow',
				'mergeTableCells',
				'tableCellProperties',
				'tableProperties'
			]
		},
		licenseKey: '',

	})
	.then(editor => {
		editorContent = editor;
	})
	.catch(error => {
		console.error('Oops, something went wrong!');
		console.error('Please, report the following error on https://github.com/ckeditor/ckeditor5/issues with the build id and the error stack trace:');
		console.warn('Build id: n3n5y5pa0kug-6p6y54g8334g');
		console.error(error);
	});
$(document).ready(() => {
	const ArticleType = document.getElementById("ArticleType"); //select element
	//Set Data of editor 
	//Fetch method "GET" to get data
	let dataId = { ArticleId: getArticleId}
	async function GetData(data) {
		let response = await fetch("/WriteArticle/GetArticleData", {
				method: "POST",
				credentials: "include",
				headers: {
					'Content-Type': 'application/json'
				},
			body: JSON.stringify(data)
		});
		var result = await response.json();
		if (result.articleContent != null) {
			$(document).ready(() => {
				const domEditableElement = document.querySelector('.ck-editor__editable');
				const editorInstance = domEditableElement.ckeditorInstance;
				editorInstance.setData(result.articleContent);
			})
		}
		ArticleType.value = result.articleTypeId;
	}
	GetData(dataId);


	editorContent.model.document.on('change', () => {
		handleEditorText.innerHTML = editorContent.getData();
		console.log(handleEditorText);
	});
	// Save when user leave or load page
	window.addEventListener("beforeunload", (event) => {
		event.returnValue = " ";
		const getTitle = document.querySelector("h1[data-placeholder]"); // title of Article
		var DataRequest = {
			contentArticle: editorContent.getData(),
			imgList: [],
			articleId: getArticleId,
			articleTypeId: ArticleType.value,
			title: getTitle.textContent
		};
		//Get image in editor Content
		const imageArr = $(".image").find("img");
		$.each(imageArr, function (index, value) { // put img into array of dataRequest
			let handleValue = value.src.toString().split("/");
			let lastElementValue = handleValue[handleValue.length - 1];
			if (DataRequest.imgList.indexOf(lastElementValue) === -1) {
				DataRequest.imgList[index] = lastElementValue.toString().replaceAll("%20", " ");
			}
		})
		//Fetch Data when unload browse
		async function PostData(data) {
			let response = await fetch("/WriteArticle/LoadArticleData", {
				method: "POST",
				credentials: "include",
				headers: {
					'Content-Type': 'application/json'
				},
				body: JSON.stringify(data)
			});
			const result = await response.json();
		}
		PostData(DataRequest);
	});
})

//Khi lấy nội dung ckeditor chúng ta k thể nào lấy dc class và id bên trong
//Vì thế ta sẽ tạo ra một div ẩn và add nội dung từ ckeditor vào

//$(document).ready(() => {
//	const domEditableElement = document.querySelector('.ck-editor__editable');
//	const editorInstance = domEditableElement.ckeditorInstance;
//	editorInstance.setData('<p>Hello world!<p>');
//})