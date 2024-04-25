//this component will display the debt
//get all savings, then display savings as an input field for users to name their debt, the date it's due, and the amount due
//need to display all savings the user has listed, while allowing them to add more and edit existing

import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getSavings, addSaving } from "../../managers/savingManager";
import "./Saving.css"

export const SavingList = ({ loggedInUser }) => {
    const [savings, setSavings] = useState([]);
    const [name, setName] = useState("")
    const [amount, setAmount] = useState("")
    const [dueDate, setDueDate] = useState("")
    const [showAddForm, setShowAddForm] = useState(false);

    const navigate = useNavigate();

    const getAndSetSavings = () => {
        getSavings().then((array) => setSavings(array))
    }

    useEffect(() => {
        getAndSetSavings()
    }, [])

    const handleAddSaving = async (e) => {
        e.preventDefault();
        const newSaving = {
            name: name,
            amount: parseFloat(amount), 
            dueDate: dueDate
        };
        await addSaving(newSaving); 
        getAndSetSavings(); 
        setName("");
        setAmount("");
        setDueDate("");
        setShowAddForm(false); 
    }

    return (
        <div className="saving-list">
            <h1 className="header">Savings</h1>
            <div className="saving-container">
                <div className="saving-item header-item">
                    <h2>Name</h2>
                    <h2>Amount</h2>
                    <h2>Date</h2>
                </div>
                {savings.map((saving) => (
                    <div key={saving.id} className="saving-item">
                        <h4>{saving?.name}</h4>
                        <h4 className="amount">${saving?.amount}</h4>
                        <h4>{saving?.date?.slice(0, 10)}</h4>
                    </div>
                ))}
            </div>
            <button className="add-btn" onClick={() => setShowAddForm(true)}>Add Savings</button>
            {showAddForm && (
                <form onSubmit={handleAddSaving}>
                    <input type="text" placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} required />
                    <input type="number" placeholder="Amount" value={amount} onChange={(e) => setAmount(e.target.value)} required />
                    <input type="date" placeholder="Due Date" value={dueDate} onChange={(e) => setDueDate(e.target.value)} required />
                    <button type="submit">Submit</button>
                </form>
            )}
        </div>
    )
}
