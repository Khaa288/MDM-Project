function SearchBox() {
  return (
    <div className="container bg-light border border-warning rounded mt-5">
        <div className="row p-3 gx-2">
            <div className="col">
                <div className="border rounded bg-white">
                    <div className="p-2">
                        <input className="form-check-input" type="checkbox" value=""/>
                    </div>
                    
                    <div className="p-4">
                        <h4>Gợi ý 1</h4>
                        <p>Gợi ý lại những chuyến xe cũ</p><br />
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="border rounded bg-white">
                    <div className="p-2">
                        <input className="form-check-input" type="checkbox" value=""/>
                    </div>
                    
                    <div className="p-4">
                        <h4>Gợi ý 2</h4>
                        <p>Gợi ý những chuyến xe mới dựa trên địa điểm của cá nhân</p>
                    </div>
                </div>
            </div>
            <div className="col">
                <div className="border rounded bg-white">
                    <div className="p-2">
                        <input className="form-check-input" type="checkbox" value=""/>
                    </div>
                    
                    <div className="p-4">
                        <h4>Gợi ý 3</h4>
                        <p>Gợi ý những chuyến xe mới dựa trên địa điểm của toàn bộ user</p>
                    </div>
                </div>
            </div>
        </div>

        <div className="row text-center p-3">
            <div className="col-5"></div>
            <button className="col-2 rounded text-white rounded-pill border p-2" style={{backgroundColor: "#FB923C"}}>
                Gợi ý
            </button>
            <div className="col-5"></div>
        </div>
    </div>
  )
}

export default SearchBox
