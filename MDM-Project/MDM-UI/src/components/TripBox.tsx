import TripCard from './TripCard'

function TripBox() {
  return (
    <div className="container bg-light border border-warning rounded mt-5 p-3">
        <TripCard/>
        <TripCard/>
        <TripCard/>
        <TripCard/>
        <TripCard/>
    </div>
  )
}

export default TripBox
