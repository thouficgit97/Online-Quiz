function createQuestion()
{
    let quizQuestions = document.getElementById("quiz-questions");
    quizQuestions.append(document.createElement("hr"));
    let question = document.createElement("div");
    question.className = "question";

    let questionText = document.createElement("input");

    let allowMultiple = document.createElement("input");
    allowMultiple.type = "checkbox";
    allowMultiple.onchange = () =>
        changeOptionType(question, allowMultiple.checked);

    let allowMultipleLabel = document.createElement("label");
    allowMultipleLabel.innerHTML = "Allow Multiple Answers";

    question.appendChild(questionText);

    question.appendChild(document.createElement("br"));

    question.appendChild(allowMultiple);
    question.appendChild(allowMultipleLabel);

    question.appendChild(document.createElement("br"));

    let optionButton = document.createElement("button");
    optionButton.innerHTML = "Add option";
    optionButton.onclick = () =>
        createOption(question, allowMultiple.checked);

    question.appendChild(optionButton);

    quizQuestions.appendChild(question);
}

function createOption(question, checked) {
    let option = document.createElement("div");
    option.className = "option";

    let inputType = document.createElement("input");
    inputType.type = checked ? "checkbox" : "radio";

    if (!checked) {
        inputType.name = "selectionGroup";
    }

    let optionText = document.createElement("input");
    optionText.type = "text";

    option.appendChild(inputType);
    option.appendChild(optionText);

    question.appendChild(option);
}

function changeOptionType(question, checked) {

    let options = question.querySelectorAll(".option input[type='checkbox'], .option input[type='radio']");

    console.log("Options found:", options.length);
    console.log("Allow multiple:", checked);

    options.forEach(input => {

        input.type = checked ? "checkbox" : "radio";

        if (!checked) {
            input.name = "selectionGroup";
        } else {
            input.removeAttribute("name");
        }

        console.log("Changed input type to:", input.type);
    });
}

