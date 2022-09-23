using UnityEngine;
using Spine.Unity;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    // ���� ĳ���� ���� ��ũ��Ʈ
    public float speed = 0; // ĳ���� ���ǵ�
    public float speed_bar = 0;
    public float jumppower; // ������
    public float delay;
    float time;
    public bool onland;
    SpriteRenderer main_xy;
    Rigidbody2D work_ab;
    public bool rope_ud;
    private Rigidbody2D UD;
    public int tt_rock = 0;
    public Transform Fire01;
    public Transform Fire02;
    public GameObject throw_rock;
    public bool fall_die;
    CapsuleCollider2D cap;
    CapsuleCollider2D coll;
    public SkeletonAnimation skeleton3D;
    public AnimationReferenceAsset[] AnimeClip;
    Vector3 movement;
    public bool isrope;
    public bool isjump;
    public bool RightWalk;
    public bool LeftWalk;
    public bool isIdel;

    void Start()
    {
        work_ab = gameObject.GetComponent<Rigidbody2D>();
        UD = GetComponent<Rigidbody2D>();
        main_xy = gameObject.GetComponent<SpriteRenderer>();
        cap = gameObject.GetComponent<CapsuleCollider2D>();
        fall_die = false;
        coll = GetComponent<CapsuleCollider2D>();
        isrope = false;
        isjump = false;
        RightWalk = false;
        LeftWalk = false;
        isIdel = false;
    }


    void FixedUpdate()
    {
            Walk();
            Rope();
    }

    private void Update()
    {
        if (movement == Vector3.zero&& !isrope && !isjump&&isIdel)//������ �ִϸ��̼�
        {
            SetAnim("Idel"); // �⺻ �ִϸ��̼�
            RightWalk = false;
            LeftWalk = false;
            isIdel = false;
        }
        if (movement.x > 0 &&!RightWalk)
        {
            if(!isjump)
            SetAnim("walk"); //������ �ȱ� �ִϸ��̼�
            transform.rotation = Quaternion.Euler(0, 0, 0);
            RightWalk = true;
            LeftWalk = false;
            isIdel = true;
        }
        if(movement.x < 0 && !LeftWalk)
        {
            if(!isjump)
            SetAnim("walk"); //���� �ȱ� �ִϸ��̼�
            transform.rotation = Quaternion.Euler(0, 180, 0);
            LeftWalk = true;
            RightWalk = false;
            isIdel = true;
        }
                Jump();
                Throw_rock();
                Pass_platform();
        time += Time.deltaTime;
        if (onland && fall_die)
        {
            SetAnim("Dead");//���� �ִϸ��̼�
            Invoke("Restart", 1.0f);
        }

    }



    void Walk() // ��, �� ������ �ڵ�
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
        transform.position += movement * Time.deltaTime * speed;
    }

    void Jump() // ���� �ڵ�
    {
        if (Input.GetButtonDown("Jump") && !onland == false && time > delay)
        {
            Vector2 jump = new Vector2(0, jumppower);
            work_ab.AddForce(jump, ForceMode2D.Impulse);
            time = 0;
            SetAnim("Jump");
            isjump = true;
            isIdel = true;
            if (transform.rotation == Quaternion.Euler(0, 0, 0))
                RightWalk = true;
            if (transform.rotation == Quaternion.Euler(0, 180, 0))
                LeftWalk = true;
        }
        if (time > delay && isjump)
        {
            isjump = false;
            if (LeftWalk)
                LeftWalk = false;
            if (RightWalk)
                RightWalk = false;
        }
    }

    void Rope() // ���� ������ ��, �� �̵� �ڵ�
    {
        Vector3 movement = Vector3.zero;
        if (Input.GetAxisRaw("Vertical") > 0 && rope_ud && isrope)
        {
            movement = Vector3.up;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && rope_ud && isrope)
        {
            movement = Vector3.down;
        }
        if (Input.GetAxisRaw("Vertical") > 0 && rope_ud && isrope == false)
        {
            movement = Vector3.up;
            SetAnim("Climb rope");
            isrope = true;
            RightWalk = true;
        }
        if (Input.GetAxisRaw("Vertical") < 0 && rope_ud && isrope == false)
        {
            movement = Vector3.down;
            SetAnim("Climb rope");
            isrope = true;
            RightWalk = true;
        }
        transform.position += movement * Time.deltaTime * (speed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("rock"))
        {

            SetAnim("Dead");
            Invoke("Restart", 1.0f);
        }
        if (collision.gameObject.CompareTag("rock"))
        {

            SetAnim("Dead");
            Invoke("Restart", 1.0f);
        }
        if (collision.gameObject.CompareTag("trap"))
        {
            fall_die = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            onland = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        onland = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("rope")) // �������� �귯������ ����
        {
            rope_ud = true;
            UD.gravityScale = 0;
            UD.velocity = new Vector3(0, 0, 0);
            coll.isTrigger = true;
            if (movement == Vector3.zero)
                isrope = false;
        }
        if(collision.CompareTag("Clear"))
        {
            SetAnim("Ending");
            Invoke("GameEnding", 3.0f);
        }
        if (collision.gameObject.name == "RottenRope")
        {
            fall_die = true;
        }
    }
    public void GameEnding()
    {
        Restart();
    }

    public void Restart()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("rope"))
        {
            rope_ud = false;
            UD.gravityScale = 3f;
            coll.isTrigger = false;
            isrope = false;
        }
       

    }

    void Throw_rock() // �� ������
    {
        if (Input.GetButtonDown("Fire1") && main_xy.flipX == false && tt_rock > 0)
        {
            GameObject obj = Instantiate(throw_rock, Fire01.transform.position, Fire01.transform.rotation);
            obj.transform.localScale = new Vector3(1, 1, 1);
            tt_rock--;
        }

        if (Input.GetButtonDown("Fire1") && main_xy.flipX == true && tt_rock > 0)
        {
            GameObject obj = Instantiate(throw_rock, Fire02.transform.position, Fire02.transform.rotation);
            obj.transform.localScale = new Vector3(-1, 1, 1);
            tt_rock--;
        }
    }

    void Pass_platform() // �ٴ� ��� �ڵ�
    {
        if (Input.GetKey(KeyCode.DownArrow) && Input.GetButton("Fire1"))
        {
            cap.isTrigger = true;

            Invoke("Re_platform", 1f);
        }
    }
    void Re_platform()
    {
        cap.isTrigger = false;
    }


    void SetAnim(string _name, bool _loop = true)
    {
        if (skeleton3D != null) //������ �����ϴ� ���
        {
            skeleton3D.AnimationState.SetAnimation(0, _name, _loop);   //������ ���ϸ��̼�
        }
    }
}

