import axios from "axios"
import { useState } from "react";

interface SearchBoxProps {
  onButtonClick: (data: TripResponse[]) => void; // Define the prop type
}

function SearchBox(props: SearchBoxProps) {
  const [radio1, setRadio1] = useState(false)
  const [radio2, setRadio2] = useState(false)
  const [radio3, setRadio3] = useState(false)

  const handleRecommendationClick = async () => {
    const response = await axios.get('http://localhost:5253/api/Recommendation', {
        params: {
          userId: "1",
          isRecommend1: radio1,
          isRecommend2: radio2,
          isRecommend3: radio3,
        } 
    })
    props.onButtonClick(response.data)
  }

  const handleRadioClick = (radio: string) => {
    if (radio == "1") {
        setRadio1(true)
        setRadio2(false)
        setRadio3(false)
    }

    if (radio == "2") {
        setRadio1(false)
        setRadio2(true)
        setRadio3(false)
    }

    if (radio == "3") {
        setRadio1(false)
        setRadio2(false)
        setRadio3(true)
    }
  }

  return (
    <div className="container bg-light border border-warning rounded mt-5">
        <div className="row p-3 gx-2">
            <div className="col">
                <div className="border rounded bg-white">
                    <div className="p-2">
                        <input 
                            className="form-check-input" 
                            type="radio" 
                            value="1"
                            checked= {radio1} 
                            onClick={(e) => handleRadioClick(e.currentTarget.value)}
                        />
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
                    <input 
                            className="form-check-input" 
                            type="radio" 
                            value="2"
                            checked = {radio2}
                            onClick={(e) => handleRadioClick(e.currentTarget.value)}
                        />
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
                    <input 
                            className="form-check-input" 
                            type="radio" 
                            value="3"
                            checked = {radio3}
                            onClick={(e) => handleRadioClick(e.currentTarget.value)}
                        />
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
            <button 
                className="col-2 rounded text-white rounded-pill border p-2" style={{backgroundColor: "#FB923C"}}
                onClick={() => handleRecommendationClick()}
            >
                Gợi ý
            </button>
            <div 
                className="col-5 text-end"
                style={{ cursor: "pointer" , color: "#FB923C"}}
                onClick={() => {
                    setRadio1(false)
                    setRadio2(false)
                    setRadio3(false)
                    handleRecommendationClick()
                }}            
            >
                Gợi ý tất cả
            </div>
        </div>
    </div>
  )
}

export default SearchBox
