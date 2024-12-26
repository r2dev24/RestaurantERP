# RestaurantERP - Development
**레스토랑 지점, 사용자, 역할 관리를 위한 종합 ERP 시스템**  
기술 스택: **C#, ASP.NET Core MVC, SQL Server**


## 개발 진행 상황

### 2024년 12월 26일
#### 추가된 기능
1. **상세 보기 버튼 업데이트**
   - 각 사용자의 이메일을 동적으로 전달하기 위해 `data-email` 속성 추가.
   - Ajax 요청을 구성하여 서버와 통신 처리.

2. **JavaScript를 사용한 Ajax 요청**
   - `fetch`를 이용해 상세 보기 버튼 클릭 시 서버에서 Partial View 데이터를 가져옴.
   - Modal 콘텐츠에 동적으로 데이터를 삽입.

3. **컨트롤러 구현**
   - `GetUserDetail` 액션을 생성하여 이메일로 사용자 데이터를 가져오고 Partial View 반환.

4. **Partial View**
   - `_UserDetail.cshtml`을 설계하여 이름, 이메일, 연락처 등의 사용자 세부 정보를 표시.

5. **데이터베이스 설계**
   - `Branch`와 `BranchAddress` 테이블을 설계하고 외래 키 관계를 설정.

6. **지점 관리**
   - `BranchController`를 생성하고 `AddNewBranch` 액션을 구현.
   - 로그인된 사용자의 이메일로 계정을 조회하여 지점 데이터를 저장.

7. **지점 추가 뷰**
   - `AddBranch` Razor View를 작성하여 지점 생성 폼 구현.
   - `asp-for`와 Bootstrap을 사용하여 UI 스타일링 및 유효성 검사 적용.

8. **버그 수정**
   - 유효성 검사 실패 시 오류를 로깅.
   - 외래 키 관계와 데이터 저장 문제를 해결.

---

### 2024년 12월 25일
#### 삭제 기능 구현
- 이메일을 기반으로 사용자를 삭제하는 로직 구현.
- `FirstOrDefaultAsync`를 사용하여 사용자 데이터를 조회 및 삭제.
- 성공적으로 삭제 후 사용자 목록 페이지로 리디렉션.

---

### 2024년 12월 24일
#### SignIn View
1. **공개 및 권한 있는 접근**
   - 공개 접근: `Home/Index`
   - 권한 있는 사용자만 접근 가능: `Main/Index`
   - Claims를 사용하여 인증 처리.

2. **컨트롤러**
   - `Home` 및 `Main`: 뷰 컨트롤러.
   - `AuthController`: 로그인 및 로그아웃 처리.

3. **ERP 사용자 관리**
   - 사용자 역할, 이메일, 이름, 연락처를 Bootstrap 스타일 테이블로 표시.
   - 각 사용자에 대해 삭제 및 상세 보기 버튼 포함.
   - `switch` 문을 활용한 동적 역할 표시.
   - Bootstrap 디자인을 적용한 대규모 데이터셋 페이지네이션 지원.

4. **향후 개선 사항**
   - 삭제, 상세 조회, 검색, 필터링 기능 추가 예정.
