const API_KEY = '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';
async function GPTChat(mensaje) {
    const res = await fetch('https://api.openai.com/v1/chat/completions', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + API_KEY
        },
        body: JSON.stringify({
            model: 'gpt-3.5-turbo',
            messages: [
                {
                    "role": "user",
                    "content": mensaje
                }
            ],
            max_tokens: 150,
            temperature: 0.7,
        })
    })

    return await res.json()
}

const prompt = document.querySelector('#prompt');
const enviar = document.querySelector('#generate');
const output = document.querySelector('#output');

enviar.addEventListener('click', async () => {
    var now = new Date(Date.now()).toLocaleString();
    $("#admin-msg").prop("hidden", true);
    $("#welcome-msg").prop("hidden", true);
    $("#user-time").text(now);
    $("#user-msg").prop("hidden", false);
    let pregunta = $("#prompt").val();
    $("#prompt").val("");
    $("#pregunta").text(pregunta);
    if (!pregunta) return
    const respuesta = await GPTChat(pregunta);
    now = new Date(Date.now()).toLocaleString();
    $("#admin-time").text(now);
    $("#admin-msg").prop("hidden", false);
    $("#output").text(respuesta.choices[0].message.content);
/*    output.innerHTML = respuesta.choices[0].message.content
*/    
})