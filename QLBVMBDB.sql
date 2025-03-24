DROP DATABASE IF EXISTS QLBVMBDB;

CREATE DATABASE IF NOT EXISTS QLBVMBDB;
USE QLBVMBDB;

CREATE TABLE IF NOT EXISTS THAMSO
(
	SoSanBayTGToiDa INT NOT NULL,
    TGBayToiThieu INT NOT NULL, -- phut
    TGDungToiThieu INT NOT NULL, -- phut
    TGDungToiDa INT NOT NULL -- phut
);    

CREATE TABLE IF NOT EXISTS SANBAY
(
	MaSanBay VARCHAR(7) PRIMARY KEY,
    TenSanBay VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS HANGGHE
(
	MaHangGhe VARCHAR(7) PRIMARY KEY,
    TenHangGhe VARCHAR(100) NOT NULL
);

CREATE TABLE IF NOT EXISTS CHUYENBAY
(
	MaChuyenBay VARCHAR(7) PRIMARY KEY,
    MaSanBayDi VARCHAR(7) NOT NULL,
    MaSanBayDen VARCHAR(7) NOT NULL,
    NgayGioBay DATETIME NOT NULL,
    ThoiGianBay INT, -- phut
    FOREIGN KEY (MaSanBayDi) REFERENCES SANBAY(MaSanBay),
    FOREIGN KEY (MaSanBayDen) REFERENCES SANBAY(MaSanBay)
);

CREATE TABLE IF NOT EXISTS CTCHUYENBAY
(
	MaChuyenBay VARCHAR(7) NOT NULL,
    MaSanBayTG VARCHAR(7) NOT NULL,
	ThoiGianDung INT, -- phut
    GhiChu VARCHAR(300),
    PRIMARY KEY (MaChuyenBay, MaSanBayTG),
    FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay),
    FOREIGN KEY (MaSanBayTG) REFERENCES SANBAY(MaSanBay)
);

CREATE TABLE IF NOT EXISTS HANGVECB
(
	MaHangGhe VARCHAR(7) NOT NULL,
    MaChuyenBay VARCHAR(7) NOT NULL,
    SoLuongGhe INT NOT NULL,
    PRIMARY KEY (MaHangGhe, MaChuyenBay),
    FOREIGN KEY (MaHangGhe) REFERENCES HANGGHE(MaHangGhe),
    FOREIGN KEY (MaChuyenBay) REFERENCES CHUYENBAY(MaChuyenBay)
);

INSERT INTO SANBAY VALUES ('SB00001', 'Sân bay California'), ('SB00002', 'Sân bay New York'), ('SB00003', 'Sân bay Texas');

SELECT * FROM SANBAY;

SHOW TABLES;
	