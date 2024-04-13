


public interface IEnemy : IPawn
{
    //Como ele busca o jogador
    public void Search();

    //Comportamento dele ao ser desativado
    public void Disable();

}

/*
 * 
 * public Collision2D searchArea;
 * private void OnTriggerEnter2D(Collision collision)
 * {
 *      if(collision.GameObject.tag == "player")
 *      {
 *          collision.gameObject.GetComponent<PlayerScript>.ApplyDamage(1)
 *      }
 * }
 * 
 * public void Search()
 * {
        searchArea.

   }
 * 
 */