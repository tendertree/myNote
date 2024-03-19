function Stack(params: string[]): number[] {
	let stack: number[] = [];
	for (let instruction of params) {
		if (instruction == "peek") {
			if (stack.length > 0) {
				console.log(stack[stack.length - 1]);

			} else {
				console.log("stack is empty");

			}

		} else if (instruction == "pop") {
			if (stack.length > 0) {
				stack.pop();
			} else {
				console.log("cannot pop");

			}

		} else {
			if (instruction.startsWith("push")) {
				const dataString: string = instruction.slice(5);
				const data: number = parseFloat(dataString);
				if (!isNaN(data)) {
					stack.push(data);
				} else {
					console.log("invalid data format");

				}
				console.log("invalid string");


			}

		}
	}
	return stack;
}
