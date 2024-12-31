### Sign In (로그인)
![스크린샷 2024-12-31 142016](https://github.com/user-attachments/assets/be39278c-5c08-4e13-a2e4-92ff75d488f9)
**기능**
    * Claim과 Cookie를 사용해 사용자 인증 처리.
    * 비밀번호는 HashPassword를 사용해 암호화.

### Add New User (사용자 추가)
![스크린샷 2024-12-31 142040](https://github.com/user-attachments/assets/fe7e37c6-f5c4-4021-91a5-b4cbeb4eec34)
**기능**
    * ORM을 사용해 DB에 사용자 데이터를 추가.
    * Navbar 우측에 로그인한 사용자 정보 표시.
    * 세션 유지 시간을 30분으로 설정.

### User List(사용자 리스트)
![스크린샷 2024-12-31 142053](https://github.com/user-attachments/assets/4a6a3536-d325-402f-a482-31f8694bf7c5)
**기능**
    * 컨트롤러에서 ORM을 사용해 사용자 정보를 출력.

### User Detail
![스크린샷 2024-12-31 142108](https://github.com/user-attachments/assets/c5a8a49b-9415-4818-b0c5-5a091ed287b9)
**기능**
    * Bootstrap Modal을 사용한 팝업 형태로 사용자 정보 표시.
    * ViewData를 활용해 데이터 모델 바인딩 및 출력.

### Add Employee(직원 추가)
![스크린샷 2024-12-31 142121](https://github.com/user-attachments/assets/f981f9df-5f22-4a72-afe8-4ab3df086538)
**기능**
    * 컨트롤러에서 Branch와 Role 데이터를 ORM으로 가져와 바인딩.
    * 입력된 직원 데이터를 통합된 모델에서 개별 모델로 변환 후 DB에 저장.
    * Try-Catch를 사용해 에러를 핸들링.

### Employee Payroll (직원 급여 입력)
![스크린샷 2024-12-31 142130](https://github.com/user-attachments/assets/be79877f-9b33-4419-83be-70d6f641f59f)
**급여 정보 입력**
    * PayType: 
      * Hourly(시간제), Daily(일당제), Monthly 월급제
      * 각 급여별로 계산 방법 다르게 설정
    * Province
      * 캐나다의 모든 주 세율 적용
      * 주 선택 후 급여 정보 입력시 자동으로 세율 적용하여 금액 출력
      * 동적으로 사용하기 위해 JS로 계산 로직 추가

### Employee List(직원 리스트)
![스크린샷 2024-12-31 142137](https://github.com/user-attachments/assets/ff8e2f61-ca94-44b7-bdcd-155f96bbb245)
**기능**
    * ORM과 리스트를 사용해 직원 데이터를 출력.
    * 삭제 기능 제공.

### Employee Detail (직원 상세 정보)
![스크린샷 2024-12-31 142145](https://github.com/user-attachments/assets/0330661b-3479-410e-8c02-ba13b831d45f)
**기능**
    * 직원의 상세 정보와 급여 정보를 출력.

