namespace SnowBoardShopProject
{
    public abstract class ForggotPassHendler
    {
        protected ForggotPassHendler Next;
        public void SetNext(ForggotPassHendler next)
        {
            this.Next = next;
        }

        public abstract bool StepOne(string username);
        public abstract bool StepTwo(string username);

        public abstract bool End(string username);

        //public abstract bool HendleRequest(string Email);

    }
}
