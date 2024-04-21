interface TripCardProps {
  trip: TripResponse
}

function TripCard(props: TripCardProps) {
  console.log(props.trip.destinationName);
  return (
    <div className="my-2 border border-3 rounded bg-white pt-3">
        <div className="row px-5">
          <div className="col-6 pb-3">
            <div className="row col col-12">
              <div className="col-4 text-start"><h2>{props.trip.startTime}:00</h2></div>

              <div className="col-4 text-secondary text-center">
              <div className="col-12">{parseInt(props.trip.arrivedTime!) - parseInt(props.trip.startTime!)} giờ</div>
                <div className="col-12">Chuyến {props.trip.tripId}</div>
              </div>
              
              <div className="col-4 text-end"><h2>{props.trip.arrivedTime}:00</h2></div>
            </div>

            <div className="row col col-12">
              <div className="col-6 text-start">{props.trip.originName}</div>
              <div className="col-6 text-end">{props.trip.destinationName}</div>
            </div>
          </div>

          <div className="col-2">
            {/* For white space only */}
          </div>

          <div className="col-4">
            <div className="row col col-12 text-center">
              <div className="col col-6">{props.trip.vehicleType}</div>
              <div className="col col-6 text-success">Số chỗ trống : {props.trip.emptySeats}</div>
            </div>
            <div className="col col-12 text-end px-5">200.000đ</div>
          </div>
        </div>

        <hr />

        <div className="row text-center">
          <div className="row col col-8 pt-2">
            <div className="col col-2">Chọn ghế</div>
            <div className="col col-2">Lịch trình</div>
            <div className="col col-2">Trung chuyển</div>
            <div className="col col-2">Chính sách</div>
          </div>
          <div className="col col-4 pb-2">
            <button className="rounded m-2 text-white rounded-pill border p-2" style={{backgroundColor: "#FB923C"}}>
              Chọn chuyến
            </button>
          </div>
          
        </div>
    </div>
  )
}

export default TripCard
