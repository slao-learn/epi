class OddEvenMonitor {

	public static final boolean ODD_TURN = true;
	public static final boolean EVEN_TURN = false;
	private boolean turn = ODD_TURN;

	public synchronized void waitForTurn(boolean waitTurn) {
		while (turn != waitTurn) {
			try {
				wait();
			} catch (Exception e) {
			}
		}
	}

	public synchronized void flipTurn() {
		turn ^= true;
		notify();
	}
}

class OddThread implements Runnable {

	private final OddEvenMonitor mMonitor;

	public OddThread(OddEvenMonitor monitor) {
		mMonitor = monitor;
	}

	@Override
	public void run() {
		for (int i = 1; i <= 100; i += 2)
		{
			mMonitor.waitForTurn(OddEvenMonitor.ODD_TURN);
			System.out.println(i);
			mMonitor.flipTurn();
		}
	}
}

class EvenThread implements Runnable {

	private final OddEvenMonitor mMonitor;

	public EvenThread(OddEvenMonitor monitor) {
		mMonitor = monitor;
	}

	@Override
	public void run() {
		for (int i = 2; i <= 100; i += 2)
		{
			mMonitor.waitForTurn(OddEvenMonitor.EVEN_TURN);
			System.out.println(i);
			mMonitor.flipTurn();
		}
	}
}

public class P20_3 {

	public static void main(String[] args) {
		OddEvenMonitor monitor = new OddEvenMonitor();
		Thread T1 = new Thread(new OddThread(monitor));
		Thread T2 = new Thread(new EvenThread(monitor));
		T1.start();
		T2.start();
		try {
			T1.join(); T2.join();
		} catch (Exception e) {
		}
	}
}
