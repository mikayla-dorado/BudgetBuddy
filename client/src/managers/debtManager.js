const _apiUrl = "/api/debt";

export const getDebts = () => {
    return fetch(_apiUrl).then((res) => res.json())
}

//not sure if this format is correct
export const addDebt = (debt) => {
    return fetch(`${_apiUrl}/debts`, {
        method: "POST",
        headers: {
            "Content-type": "application/json"
        },
        body: JSON.stringify(debt)
    })
}
//not working in postman