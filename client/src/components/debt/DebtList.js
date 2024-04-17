//this component will display the debt
//get all debts, then display debts as an input field for users to name their debt, the date it's due, and the amount due
//need to display all debts the user has listed, while allowing them to add more and edit existing

import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getDebts } from "../../managers/debtManager";
import "./Debt.css"

export const DebtList = ({ loggedInUser }) => {
    const [debts, setDebts] = useState([]);
    const [name, setName] = useState("")
    const [amount, setAmount] = useState("")
    const [userProfile, setUserProfile] = useState([])
    const [dueDate, setDueDate] = useState("")

    const navigate = useNavigate();

    const getAndSetDebts = () => {
        getDebts().then((array) => setDebts(array))
    }

    useEffect(() => {
        getAndSetDebts()
    }, [])


    return (
        <div className="debt-list">
            <h1 className="header">Debts</h1>
            <div className="debt-container">
                {debts.map((debt) => (
                    <div key={debt.id} className="debt-item">
                        <h3>Name: {debt?.name}</h3>
                        <h3>Amount: ${debt?.amount}</h3>
                        <h3>Due Date: {debt?.dueDate?.slice(0, 10)}</h3>
                    </div>
                ))}
            </div>
        </div>
    )
}

//! how do  i get the debts to display in the return? do i map over them? just call {debt.name}???
//i know the API works because the info is in swagger, but how do i access this to display on the scren?
//? i needed to map through the 'debts' before i could access the debt properties