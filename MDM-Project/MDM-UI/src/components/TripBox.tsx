import TripCard from './TripCard'

interface TripBoxProps {
  tripData: TripResponse[];
}

function TripBox(props: TripBoxProps) {
  return (
    <div className="container bg-light border border-warning rounded mt-5 p-3">
       {
        props.tripData.length > 0 && props.tripData.map((value) => (<TripCard trip={value}/>))
       }
    </div>
  )
}

export default TripBox
