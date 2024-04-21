import { useState } from 'react';
import Navbar from '../components/Navbar'
import SearchBox from '../components/SearchBox'
import TripBox from '../components/TripBox'

function Home() {
  const [trips, setTrip] = useState<TripResponse[]>([]);

  const handleButtonClick = (data: TripResponse[]) => {
    setTrip(data);
    console.log(data); // Log in parent
  };

  return (
    <div>
      <Navbar/>
      <h3 className="text-center text-success pt-5">Gợi ý lịch trình</h3>
      <SearchBox onButtonClick={handleButtonClick}/>
      <TripBox tripData = {trips}/>
    </div>
  )
}

export default Home
