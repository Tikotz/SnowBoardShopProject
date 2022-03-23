namespace SnowBoardShopProject
{
    public abstract class ForggotPassHendler
    {
        protected ForggotPassHendler Next;
        public void SetNext(ForggotPassHendler next)
        {
            this.Next = next;
        }

        public abstract bool HendleRequest(string username);
        //public abstract void HendleRequest(string Email);

    }
}
