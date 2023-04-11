function test(successCallback, errorCallBack) {
	isSuccess = true;
	if (isSuccess) {
		successCallback();
	} else {
		errorCallBack();
	}
}

test(
	function () {
		console.log("başarılı!");
	},
	() => {
		console.log("hata verdi");
	}
);

let promise = new Promise(function (resolve, reject) {}).then(
	function (result) {
		console.log("Ok");
	},
	function (error) {
		console.log("Error");
	}
);
