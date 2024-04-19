function Navbar() {
    return (
        <div className="px-5 bg-light d-flex justify-content-center">
            <nav className="navbar navbar-expand-lg navbar-light bg-light d-flex justify-content-center">
                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto fw-bold">
                        <li className="nav-item px-2">
                            <a className="nav-link" href="#">Trang chủ</a>
                        </li>
                        <li className="nav-item px-2">
                            <a className="nav-link" href="#">Lịch trình</a>
                        </li>
                        <li className="nav-item px-2">
                            <a className="nav-link" href="#">Gợi ý lịch trình</a>
                        </li>
                        <li className="nav-item px-2">
                            <a className="nav-link" href="#">Hóa đơn</a>
                        </li>
                        <li className="nav-item px-2">
                            <a className="nav-link" href="#">Tra cứu</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
    )
}

export default Navbar
