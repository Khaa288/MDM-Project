import Navbar from '../components/Navbar'
import SearchBox from '../components/SearchBox'
import TripBox from '../components/TripBox'

function Home() {
  return (
    <div>
      <Navbar/>
      <h3 className="text-center text-success pt-5">Gợi ý lịch trình</h3>
      <SearchBox/>
      <TripBox/>
    </div>
  )
}

export default Home
