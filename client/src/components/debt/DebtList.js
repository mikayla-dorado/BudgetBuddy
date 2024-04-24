//this component will display the debt
//get all debts, then display debts as an input field for users to name their debt, the date it's due, and the amount due
//need to display all debts the user has listed, while allowing them to add more and edit existing

// import { useEffect, useState } from "react"
// import { useNavigate } from "react-router-dom"
// import { getDebts } from "../../managers/debtManager";
// import "./Debt.css"

// export const DebtList = ({ loggedInUser }) => {
//     const [debts, setDebts] = useState([]);
//     const [name, setName] = useState("")
//     const [amount, setAmount] = useState("")
//     const [userProfile, setUserProfile] = useState([])
//     const [dueDate, setDueDate] = useState("")

//     const navigate = useNavigate();

//     const getAndSetDebts = () => {
//         getDebts().then((array) => setDebts(array))
//     }

//     useEffect(() => {
//         getAndSetDebts()
//     }, [])


//     return (
//         <div className="debt-list">
//             <h1 className="header">Debts</h1>
//             <div className="debt-container">
//                 <div className="debt-item header-item">
//                     <h2>Name</h2>
//                     <h2>Amount</h2>
//                     <h2>Due Date</h2>
//                 </div>
//                 {debts.map((debt) => (
//                     <div key={debt.id} className="debt-item">
//                         <h4>{debt?.name}</h4>
//                         {/* need to fix the styling so 
//                         that larger numbers don't get off center */}
//                         <h4 className="amount">${debt?.amount}</h4>
//                         <h4>{debt?.dueDate?.slice(0, 10)}</h4>
//                     </div>
//                 ))}
//             </div>
//         </div>
//     )
// }




import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"
import { getDebts, addDebt } from "../../managers/debtManager"; // Import addDebt function
import "./Debt.css"

export const DebtList = ({ loggedInUser }) => {
    const [debts, setDebts] = useState([]);
    const [name, setName] = useState("")
    const [amount, setAmount] = useState("")
    const [dueDate, setDueDate] = useState("")
    const [showAddForm, setShowAddForm] = useState(false); // State to manage form visibility

    const navigate = useNavigate();

    const getAndSetDebts = () => {
        getDebts().then((array) => setDebts(array))
    }

    useEffect(() => {
        getAndSetDebts()
    }, [])

    const handleAddDebt = async (e) => {
        e.preventDefault();
        const newDebt = {
            name: name,
            amount: parseFloat(amount), // Ensure amount is parsed as a float
            dueDate: dueDate
        };
        await addDebt(newDebt); // Call addDebt function from your manager
        getAndSetDebts(); // Refresh the list of debts after adding a new debt
        // Reset form fields
        setName("");
        setAmount("");
        setDueDate("");
        setShowAddForm(false); // Hide the form after submitting
    }

    return (
        <div className="debt-list">
            <h1 className="header">Debts</h1>
            <button onClick={() => setShowAddForm(true)}>Add Debt</button>
            {showAddForm && (
                <form onSubmit={handleAddDebt}>
                    <input type="text" placeholder="Name" value={name} onChange={(e) => setName(e.target.value)} required />
                    <input type="number" placeholder="Amount" value={amount} onChange={(e) => setAmount(e.target.value)} required />
                    <input type="date" placeholder="Due Date" value={dueDate} onChange={(e) => setDueDate(e.target.value)} required />
                    <button type="submit">Submit</button>
                </form>
            )}
            <div className="debt-container">
                <div className="debt-item header-item">
                    <h2>Name</h2>
                    <h2>Amount</h2>
                    <h2>Due Date</h2>
                </div>
                {debts.map((debt) => (
                    <div key={debt.id} className="debt-item">
                        <h4>{debt?.name}</h4>
                        <h4 className="amount">${debt?.amount}</h4>
                        <h4>{debt?.dueDate?.slice(0, 10)}</h4>
                    </div>
                ))}
            </div>
        </div>
    )
}






//! how do  i get the debts to display in the return? do i map over them? just call {debt.name}???
//i know the API works because the info is in swagger, but how do i access this to display on the screen?
//? i needed to map through the 'debts' before i could access the debt properties

//! i want to be able to create a new debt, without navigating to a new page. how can a user create a new debt in the container with input fields?